using UnityEngine;

public class SnowTrigger : MonoBehaviour
{
    public ParticleSystem snowParticles;

    void Start()
    {
        if (snowParticles.isPlaying)
            snowParticles.Stop(); // Ensure snow starts off
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Snow"))
        {
            snowParticles.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Snow"))
        {
            snowParticles.Stop();
        }
    }
}
