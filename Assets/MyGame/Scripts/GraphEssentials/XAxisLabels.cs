using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XAxisLabels : MonoBehaviour
{
    public TextMeshProUGUI[] labels; // Im Inspector mit 10 Text-Objekten befüllen
    public int xNumbers;



    public void Update()
    {


        for (int i = 0; i < labels.Length; i++)
        {
            RectTransform rect = labels[i].GetComponent<RectTransform>();
            Vector2 pos = rect.anchoredPosition;

            
            pos.y = xNumbers;


            rect.anchoredPosition = pos;

        }



    }


}