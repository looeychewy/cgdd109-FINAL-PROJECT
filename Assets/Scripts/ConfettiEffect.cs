using UnityEngine;

public class ConfettiEffect : MonoBehaviour
{
    [SerializeField] ParticleSystem confettiParticles;

    public void Play()
    {
        var renderer = confettiParticles.GetComponent<ParticleSystemRenderer>();
        renderer.sortingOrder = 999;
        
        var main = confettiParticles.main;
        main.useUnscaledTime = true;

        confettiParticles.Play();
        Debug.Log("Confetti firing");
    }
}