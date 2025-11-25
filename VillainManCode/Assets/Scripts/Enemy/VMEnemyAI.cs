using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class VMEnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float contactDamage = 10f;
    [SerializeField] private float contactDamageInterval = 1f;

    private Transform player;
    private CharacterController controller;
    private float lastDamageTime;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag(VMGameConstants.PlayerTag);
        if (p != null) player = p.transform;
    }

    private void Update()
    {
        if (player == null) return;

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0f;
        if (toPlayer.sqrMagnitude < 0.01f) return;

        Vector3 dir = toPlayer.normalized;
        controller.Move(dir * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(dir);

        // Simple “if close enough, damage player”
        if (toPlayer.magnitude < 1.5f && Time.time >= lastDamageTime + contactDamageInterval)
        {
            var health = player.GetComponent<VMPlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(contactDamage);
                lastDamageTime = Time.time;
            }
        }
    }
}

