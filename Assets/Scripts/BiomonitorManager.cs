using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI Text
using TMPro; // Required for TextMeshPro

public class BiomonitorManager : MonoBehaviour
{
    public static BiomonitorManager Instance;

    private HashSet<string> completedAnimals = new HashSet<string>();

    public int CompletedCount => completedAnimals.Count;

    [SerializeField] private TextMeshProUGUI completedText; // Assign in Inspector
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        Debug.Log("BiomonitorManager initialized");
        Debug.Log("Completed animals count: " + CompletedCount);
        UpdateCompletedText();
    }

    public void RegisterCompletion(string animalName)
    {
        if (!completedAnimals.Contains(animalName))
        {
            completedAnimals.Add(animalName);
            Debug.Log($"Registered completion for {animalName}. Total now: {CompletedCount}");
            UpdateCompletedText();
        }
    }

    public bool IsAnimalCompleted(string animalName)
    {
        return completedAnimals.Contains(animalName);
    }

    private void UpdateCompletedText()
    {
        if (completedText != null)
        {
            completedText.text = $"BIOMOS COMPLETADOS: {CompletedCount}";
        }
        else
        {
            Debug.LogWarning("Completed Text UI not assigned in BiomonitorManager.");
        }
    }
}
