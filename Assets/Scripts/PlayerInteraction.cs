using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        string animalTag = other.tag;
        Debug.Log("Triggered with: " + animalTag);

        if (BiomonitorManager.Instance == null || FormManager.Instance == null)
        {
            Debug.LogError("Manager instances not found");
            return;
        }

        if (BiomonitorManager.Instance.IsAnimalCompleted(animalTag))
        {
            Debug.Log("Already completed: " + animalTag);
            return;
        }

        if (FormManager.Instance.IsFormVisible(animalTag))
        {
            Debug.Log("Form already open: " + animalTag);
            return;
        }

        FormManager.Instance.ShowForm(animalTag);
    }
}
