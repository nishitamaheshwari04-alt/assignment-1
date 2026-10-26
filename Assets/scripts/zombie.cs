using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [Header("Player")]
    public Transform xrPlayer;

    [Header("Detection")]
    public float detectionRadius = 8f;
    public float loseTargetRadius = 12f;

    [Header("Movement")]
    public float movementSpeed = 2f;
    public float stoppingDistance = 2f;

    private NavMeshAgent agent;
    private Animator animator;

    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.speed = movementSpeed;
        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = true;

        animator.applyRootMotion = false;
    }

    void Update()
    {
        if (xrPlayer == null || !agent.isOnNavMesh)
            return;

        // Horizontal distance between player and enemy
        Vector3 offset = xrPlayer.position - transform.position;
        offset.y = 0f;
        float distance = offset.magnitude;

        // Detect the player
        if (!isChasing && distance <= detectionRadius)
        {
            isChasing = true;
            agent.isStopped = false;
        }

        // Stop chasing if player escapes
        if (isChasing && distance > loseTargetRadius)
        {
            isChasing = false;
            agent.isStopped = true;
            agent.ResetPath();
        }

        // Chase XR player
        if (isChasing)
        {
            agent.SetDestination(xrPlayer.position);
        }

        // Update Idle/Walk animations
        float animationSpeed = Mathf.Clamp01(
            agent.velocity.magnitude / Mathf.Max(movementSpeed, 0.01f)
        ) * 0.5f;

        animator.SetFloat(
            "speed",
            animationSpeed,
            0.15f,
            Time.deltaTime
        );
    }

    // Visualize detection radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(
            transform.position,
            detectionRadius
        );

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(
            transform.position,
            loseTargetRadius
        );
    }
}
