using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormManager : MonoBehaviour
{
    public static FormManager Instance;

    [SerializeField] private List<FormEntry> formEntries;

    private Dictionary<string, GameObject> formPanels = new Dictionary<string, GameObject>();
    private Dictionary<string, CanvasGroup> canvasGroups = new Dictionary<string, CanvasGroup>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            foreach (var entry in formEntries)
            {
                if (!formPanels.ContainsKey(entry.animalName))
                {
                    formPanels.Add(entry.animalName, entry.panel);

                    CanvasGroup group = entry.panel.GetComponent<CanvasGroup>();
                    if (group == null)
                    {
                        group = entry.panel.AddComponent<CanvasGroup>();
                        Debug.LogWarning($"CanvasGroup missing on {entry.animalName} panel. Added one automatically.");
                    }

                    canvasGroups.Add(entry.animalName, group);

                    entry.panel.SetActive(false);
                    group.alpha = 0;
                    group.interactable = false;
                    group.blocksRaycasts = false;

                    Debug.Log($"Form for {entry.animalName} initialized.");
                }
            }

            foreach (var kvp in formPanels)
            {
                Debug.Log($"Animal: {kvp.Key}, Active: {kvp.Value.activeSelf}");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowForm(string animalName)
    {
        if (formPanels.ContainsKey(animalName))
        {
            Debug.Log($"Showing form for {animalName}");

            formPanels[animalName].SetActive(true);
            StartCoroutine(FadeIn(canvasGroups[animalName]));
        }
    }

    public void HideForm(string animalName)
    {
        if (formPanels.ContainsKey(animalName))
        {
            Debug.Log($"Hiding form for {animalName}");
            StartCoroutine(FadeOut(canvasGroups[animalName], formPanels[animalName]));
        }
    }

    public bool IsFormVisible(string animalName)
    {
        Debug.Log($"Checking visibility for {animalName}");
        Debug.Log($"Form active state: {formPanels.ContainsKey(animalName)}");
        return formPanels.ContainsKey(animalName) && canvasGroups[animalName].alpha > 0.1f;
    }

    private IEnumerator FadeIn(CanvasGroup group)
    {
        float duration = 0.3f;
        float elapsed = 0f;

        group.interactable = true;
        group.blocksRaycasts = true;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            group.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        group.alpha = 1f;
    }

    private IEnumerator FadeOut(CanvasGroup group, GameObject panel)
    {
        float duration = 0.3f;
        float elapsed = 0f;

        group.interactable = false;
        group.blocksRaycasts = false;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            group.alpha = 1f - Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        group.alpha = 0f;
        panel.SetActive(false);
    }
}

[System.Serializable]
public class FormEntry
{
    public string animalName;
    public GameObject panel;
}
