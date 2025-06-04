using UnityEngine;

public class SeagullEllipseFlyer : MonoBehaviour
{
    public float xRadius = 5f;
    public float yRadius = 2f;
    public float speed = 1f;
    public bool faceLeftWhenReversing = true;
    private SpriteRenderer spriteRenderer;
    private float t;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        t += Time.deltaTime * speed;
        float x = xRadius * Mathf.Cos(t) - 9;
        float y = yRadius * Mathf.Sin(t);
        transform.localPosition = new Vector3(x, y, 0);

        // Flip sprite depending on direction
        if (Mathf.Sin(t) < 0)
        {
            if (faceLeftWhenReversing)
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        //Close bracket
    }
    // Close bracket for class
}

