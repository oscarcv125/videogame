using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteSwitcher : MonoBehaviour
{
    public Image buttonImage;       // The Image component on the button
    public Sprite normalSprite;     // Default sprite
    public Sprite selectedSprite;   // Sprite when selected

    private bool isSelected = false;

    public void Select()
    {
        isSelected = true;
        buttonImage.sprite = selectedSprite;
    }

    public void Deselect()
    {
        isSelected = false;
        buttonImage.sprite = normalSprite;
    }
}