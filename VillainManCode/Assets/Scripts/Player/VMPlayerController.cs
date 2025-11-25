using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class VMPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private Camera viewCamera;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    private VMControls controls;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new VMControls();

        if (viewCamera == null)
            viewCamera = Camera.main;

        controls.Gameplay.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable() => controls.Gameplay.Enable();
    private void OnDisable() => controls.Gameplay.Disable();

    private void Update()
    {
        Vector3 camForward = viewCamera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = viewCamera.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = camForward * moveInput.y + camRight * moveInput.x;

        if (move.sqrMagnitude > 0.01f)
        {
            controller.Move(move * moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(move);
        }

        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;
        else
            velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
