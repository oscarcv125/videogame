using UnityEngine;

public class WaveTextAnimator : MonoBehaviour
{
    public RectTransform[] letters; // Assign in inspector or via code
    public float amplitude = 20f;    // How high the wave goes
    public float frequency = 2f;     // How fast the wave moves
    public float waveOffset = 0.5f;  // Distance between peaks (per letter)

    private Vector2[] originalPositions;

    void Start()
    {
        // Save initial positions
        originalPositions = new Vector2[letters.Length];
        for (int i = 0; i < letters.Length; i++)
        {
            originalPositions[i] = letters[i].anchoredPosition;
        }
    }

    void Update()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            Vector2 pos = originalPositions[i];
            pos.y += Mathf.Sin(Time.time * frequency + i * waveOffset) * amplitude;
            letters[i].anchoredPosition = pos;
        }
    }
}
