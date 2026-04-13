// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemyMovement : MonoBehaviour
// {
//     [SerializeField] float moveSpeed = 5f;
     
//     Rigidbody2D rb;
//     Transform target;
//     Vector2 moveDirection;

//     private void Awake()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     } 


//     void Start()
//     {
//         target = GameObject.Find("PlayerSprite").transform;
//     }


//     void Update()
//     {
//         if (target)
//         {
//             Vector3 direction = (target.position - transform.position).normalized;
//             moveDirection = direction;

//             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
//             rb.rotation = angle;
//         }
//     }

//     private void FixedUpdate()
//     {
//         if (target)
//         {
//             rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
//         }

//     }
// }
