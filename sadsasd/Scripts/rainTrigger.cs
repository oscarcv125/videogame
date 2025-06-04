using UnityEngine;

public class rainTrigger : MonoBehaviour
{
    public ParticleSystem rainParticles;

    void Start()
    {
        if (rainParticles.isPlaying)
            rainParticles.Stop(); // Ensure rain starts off
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Taiga"))
        {
            rainParticles.Play();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Taiga"))
        {
            rainParticles.Stop();
        }
    }
}
