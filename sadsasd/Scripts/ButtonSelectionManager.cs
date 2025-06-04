using UnityEngine;

public class ButtonSelectionManager : MonoBehaviour
{
    public ButtonSpriteSwitcher[] buttons;

    // Must match button order: Chicken, Cow, Cat
    public string[] animalNames = { "Chicken", "Cow", "Cat" };

    private int selectedIndex = -1;

    public void OnButtonClicked(int index)
    {
        selectedIndex = index;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == index)
                buttons[i].Select();
            else
                buttons[i].Deselect();
        }
    }

    public string GetSelectedAnimal()
    {
        if (selectedIndex >= 0 && selectedIndex < animalNames.Length)
            return animalNames[selectedIndex];
        else
            return null;
    }
}
