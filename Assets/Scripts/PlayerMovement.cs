using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    
    private Rigidbody2D rb;
    private Vector2 input;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        TargetInteractable interactable = other.GetComponent<TargetInteractable>();
        if (interactable != null)
        {
            interactable.Trigger();
        }
    }
}
