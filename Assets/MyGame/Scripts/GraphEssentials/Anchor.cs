using UnityEngine;
using UnityEngine.UI;

public class Anchor : MonoBehaviour
{
    public Image[] xBars; // X-Achse
    //public Image[] yBars; // Y-Achse

    void Start()
    {
        SetAnchorsToCenter(xBars);
        //SetAnchorsToCenter(yBars);
    }

    private void SetAnchorsToCenter(Image[] bars) //Refactoting: Make Helper Methode Private
    {
        foreach (var bar in bars)
        {
            RectTransform rectTransform = bar.GetComponent<RectTransform>();
          
            rectTransform.anchorMin = new Vector2(0.5f, 0.4f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.4f);

            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0f);
        }
        

    }
}