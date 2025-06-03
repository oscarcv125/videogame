using UnityEngine;

public class ButtonSelectionManager : MonoBehaviour
{
    public ButtonSpriteSwitcher[] buttons;

    public void OnButtonClicked(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == index)
                buttons[i].Select();
            else
                buttons[i].Deselect();
        }
    }
}