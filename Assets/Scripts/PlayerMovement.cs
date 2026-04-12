using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5f;

    private Rigidbody2D rb;

    float moveX;
    float moveY;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 dir = new Vector2(moveX, moveY);
        rb.velocity = dir * maxSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            score += 1;
            other.gameObject.SetActive(false);
            Debug.Log("Picked up! Score = " + score);
        }
    }
}
