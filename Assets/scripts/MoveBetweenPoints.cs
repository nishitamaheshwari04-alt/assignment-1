using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speed = 2f;

    private Transform targetPoint;

    void Start()
    {
        targetPoint = pointB;
    }

    void Update()
    {
        // Move towards the target point
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        // Switch target when reached
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            targetPoint = targetPoint == pointB ? pointA : pointB;
        }
    }
}