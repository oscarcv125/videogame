using UnityEngine;
using TMPro; // Use TextMeshPro

public class CharacterProximityDialogue : MonoBehaviour
{
    [SerializeField] private GameObject textBoxUI; // Assign the text box UI panel
    [SerializeField] private string message = "Hola, bienvenido al laboratorio!"; // Message to show
    [SerializeField] private TMP_Text messageText; // Assign the TMP_Text component

    private void Start()
    {
        textBoxUI.SetActive(false); // Hide on start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textBoxUI.SetActive(true);
            messageText.text = message;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            textBoxUI.SetActive(false);
        }
    }
}
