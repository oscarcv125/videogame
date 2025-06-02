using UnityEngine;
using UnityEditor;
using System.IO;

public class SpriteToTexture2DConverter
{
    [MenuItem("Tools/Convert Sprite to Texture2D")]
    public static void ConvertSelectedSprite()
    {
        if (Selection.activeObject is Sprite sprite)
        {
            Texture2D original = sprite.texture;
            Rect rect = sprite.textureRect;

            Texture2D newTex = new Texture2D((int)rect.width, (int)rect.height);
            newTex.SetPixels(original.GetPixels(
                (int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height));
            newTex.Apply();

            // Encode to PNG and save
            byte[] bytes = newTex.EncodeToPNG();
            string path = EditorUtility.SaveFilePanel(
                "Save Texture2D as PNG", "Assets", sprite.name + "_cropped", "png");

            if (!string.IsNullOrEmpty(path))
            {
                File.WriteAllBytes(path, bytes);
                AssetDatabase.Refresh();
                Debug.Log("Saved: " + path);
            }
        }
        else
        {
            Debug.LogWarning("Please select a Sprite in the Project window.");
        }
    }
}
