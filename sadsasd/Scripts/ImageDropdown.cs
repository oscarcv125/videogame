using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public List<Sprite> animalSprites; // Assign in Inspector
    public Image dropdownDisplayImage; // Image showing selected

    void Start()
    {
        PopulateDropdown();
    }

    void PopulateDropdown()
    {
        dropdown.options.Clear();

        foreach (Sprite sprite in animalSprites)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.image = sprite;
            dropdown.options.Add(option);
        }

        dropdown.RefreshShownValue();

        dropdown.onValueChanged.AddListener(index =>
        {
            dropdownDisplayImage.sprite = animalSprites[index];
        });
    }
}
