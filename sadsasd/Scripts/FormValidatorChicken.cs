using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections;

public class FormValidatorChicken : MonoBehaviour
{
    public TMP_Dropdown weatherDropdown, seasonDropdown, recordDropdown, animalTypeDropdown, observationTypeDropdown;
    public TMP_InputField transectNumberField, commonNameField, individualCountField;
    public ButtonSelectionManager buttonSelectionManager;
    public TextMeshProUGUI feedbackText;
    public FormManager formManager;

    private bool formCompleted = false;

    private readonly string expectedAnimal = "Chicken";
    private readonly string expectedWeather = "Soleado";
    private readonly string expectedSeason = "Verano";
    private readonly string expectedRecord = "Fauna en transecto";
    private readonly string expectedAnimalType = "Bird";
    private readonly string expectedObservationType = "Track";
    private readonly int expectedIndividualCount = 2;
    private readonly string[] acceptedCommonNames = { "chicken", "gallina", "pollo", "avestruz" };

    public void OnSubmit()
    {
        if (formCompleted) return;

        string weather = weatherDropdown.options[weatherDropdown.value].text;
        string season = seasonDropdown.options[seasonDropdown.value].text;
        string record = recordDropdown.options[recordDropdown.value].text;
        string animalType = animalTypeDropdown.options[animalTypeDropdown.value].text;
        string observationType = observationTypeDropdown.options[observationTypeDropdown.value].text;

        string transect = transectNumberField.text.Trim();
        string commonName = commonNameField.text.Trim().ToLower();
        string individuals = individualCountField.text.Trim();

        feedbackText.fontSize = 15;

        if (string.IsNullOrEmpty(transect) || string.IsNullOrEmpty(commonName) || string.IsNullOrEmpty(individuals))
        {
            feedbackText.text = "Completa todos los campos.";
            return;
        }

        if (!int.TryParse(individuals, out int individualCount) || individualCount != expectedIndividualCount)
        {
            feedbackText.text = "Numero de individuos incorrecto.";
            return;
        }

        string selectedAnimal = buttonSelectionManager.GetSelectedAnimal();
        if (string.IsNullOrEmpty(selectedAnimal) || selectedAnimal != expectedAnimal)
        {
            feedbackText.text = "Selecciona foto correcta.";
            return;
        }

        if (
            weather == expectedWeather &&
            season == expectedSeason &&
            record == expectedRecord &&
            animalType == expectedAnimalType &&
            observationType == expectedObservationType &&
            acceptedCommonNames.Contains(commonName)
        )
        {
            feedbackText.text = "¡Formulario enviado correctamente!";
            BiomonitorManager.Instance.RegisterCompletion(expectedAnimal);
            StartCoroutine(HideFormAfterDelay());
        }
        else
        {
            feedbackText.text = "Alguna información es incorrecta.";
        }
    }

    private IEnumerator HideFormAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        formManager.HideForm(expectedAnimal);
        formCompleted = true;
    }

    public void ResetFormState()
    {
        formCompleted = false;
        feedbackText.text = "";
    }
}
