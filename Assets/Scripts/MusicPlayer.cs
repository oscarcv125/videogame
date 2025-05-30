using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource.Play(); // Plays the attached audio clip
    }
}
