using UnityEngine;
using UnityEngine.InputSystem;

public class VMPlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float attackRadius = 1f;
    [SerializeField] private float attackDamage = 25f;
    [SerializeField] private LayerMask hitMask;

    private VMControls controls;

    private void Awake()
    {
        controls = new VMControls();
        controls.Gameplay.Attack.performed += _ => DoAttack();
    }

    private void OnEnable() => controls.Gameplay.Enable();
    private void OnDisable() => controls.Gameplay.Disable();

    private void DoAttack()
    {
        Vector3 origin = transform.position + Vector3.up;
        Vector3 dir = transform.forward;

        if (Physics.SphereCast(origin, attackRadius, dir, out RaycastHit hit, attackRange, hitMask))
        {
            hit.collider.GetComponent<VMDestructible>()?.TakeDamage(attackDamage);
            hit.collider.GetComponent<VMEnemyHealth>()?.TakeDamage(attackDamage);
        }
    }
}
