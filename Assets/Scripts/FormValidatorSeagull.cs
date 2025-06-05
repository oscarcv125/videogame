using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections;

public class FormValidatorSeagull : MonoBehaviour
{
    public TMP_Dropdown weatherDropdown;
    public TMP_Dropdown seasonDropdown;
    public TMP_Dropdown recordDropdown;
    public TMP_Dropdown animalTypeDropdown;
    public TMP_Dropdown observationTypeDropdown;

    public TMP_InputField transectNumberField;
    public TMP_InputField commonNameField;
    public TMP_InputField individualCountField;

    public ButtonSelectionManager buttonSelectionManager;
    public TextMeshProUGUI feedbackText;

    public FormManager formManager;
    private bool formCompleted = false;

    private readonly string expectedAnimal = "Cow";
    private readonly string expectedWeather = "Soleado";
    private readonly string expectedSeason = "Verano";
    private readonly string expectedRecord = "Fauna en punto de conteo";
    private readonly string expectedAnimalType = "Bird";
    private readonly string expectedObservationType = "Seen";
    private readonly int expectedIndividualCount = 4;
    private readonly string[] acceptedNames = { "Seagull", "Gaviota", "gaviota", "gaviota común", "gaviota patiamarilla", "seagull" };

    public void OnSubmit()
    {
        if (formCompleted) return;

        string weather = weatherDropdown.options[weatherDropdown.value].text;
        string season = seasonDropdown.options[seasonDropdown.value].text;
        string record = recordDropdown.options[recordDropdown.value].text;
        string type = animalTypeDropdown.options[animalTypeDropdown.value].text;
        string observation = observationTypeDropdown.options[observationTypeDropdown.value].text;
        string transect = transectNumberField.text.Trim();
        string common = commonNameField.text.Trim().ToLower();
        string individuals = individualCountField.text.Trim();
        string selectedAnimal = buttonSelectionManager.GetSelectedAnimal();
        feedbackText.fontSize = 15;


        if (string.IsNullOrEmpty(transect) || string.IsNullOrEmpty(common) || string.IsNullOrEmpty(individuals))
        {
            feedbackText.text = "Completa todos los campos.";
            return;
        }

        if (!int.TryParse(individuals, out int count) || count != expectedIndividualCount)
        {
            feedbackText.text = "Número de individuos incorrecto.";
            return;
        }

        if (selectedAnimal != expectedAnimal)
        {
            feedbackText.text = "Selecciona la foto correcta.";
            return;
        }

        if (weather == expectedWeather &&
            season == expectedSeason &&
            record == expectedRecord &&
            type == expectedAnimalType &&
            observation == expectedObservationType &&
            acceptedNames.Contains(common))
        {
            feedbackText.text = "¡Formulario enviado correctamente!";
            BiomonitorManager.Instance.RegisterCompletion("Seagull");
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
        formManager.HideForm("Seagull");
        formCompleted = true;
    }

    public void ResetFormState()
    {
        formCompleted = false;
        feedbackText.text = "";
    }
}
