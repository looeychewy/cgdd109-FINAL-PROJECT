using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] AudioClip footstepClip;
    [SerializeField] float stepInterval = 0.4f;

    AudioSource audioSource;
    Rigidbody2D rb;
    float stepTimer;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

        audioSource.clip = footstepClip;
        audioSource.loop = false;
    }

    void Update()
    {
        bool isMoving = rb.velocity.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
                stepTimer = stepInterval;
            }
        }
        else
        {
            audioSource.Stop();
            stepTimer = 0f;
        }
    }
}