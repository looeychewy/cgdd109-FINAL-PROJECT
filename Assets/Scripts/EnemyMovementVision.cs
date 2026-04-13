using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    //
    [SerializeField] float visionRange = 8f;
    [SerializeField] float visionAngle = 90f;
    [SerializeField] LayerMask obstacleMask;
    
    
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;
    //
    bool playerSpotted = false;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    } 


    void Start()
    {
        target = GameObject.Find("PlayerSprite").transform;
    }

    bool canSeePlayer()
    {
        Vector2 dirToPlayer = (Vector2)target.position - (Vector2)transform.position;
        float distance = dirToPlayer.magnitude;

        if (distance > visionRange) 
        {
            return false;
        }

        float angle = Vector2.Angle(transform.up, dirToPlayer);
        if (angle > visionAngle / 2f) 
        {
            return false;
        }

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            dirToPlayer.normalized,
            distance,
            obstacleMask
        );

        return hit.collider == null;
    }


    void Update()
    {
        if (!target)
        {
            return;
        }

        if (canSeePlayer())
        {
            playerSpotted = true;
        }

        if (playerSpotted)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    private void FixedUpdate()
    {
        if (playerSpotted)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 leftEdge = Quaternion.Euler(0, 0, visionAngle / 2f) * transform.up;
        Vector3 rightEdge = Quaternion.Euler(0, 0, -visionAngle / 2f) * transform.up;

        Gizmos.DrawLine(transform.position, transform.position + leftEdge * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + rightEdge * visionRange);
    }
}
