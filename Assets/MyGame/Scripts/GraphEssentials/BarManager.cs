using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BarManager : MonoBehaviour
    
{
    public Image[] bars;
    public TextMeshProUGUI timerDisplay;

    [Header("Auto Return Settings")]
    [SerializeField] private float maxIdleTime = 20f; 
    private float dataTimer;

    void Start()
    {
        // WICHTIG: Timer beim Start auf 20s setzen
        dataTimer = maxIdleTime; 
        RefreshBars();
    }
    //Refactoring: Magic Numbers ersetzt 

    public void RefreshBars() 
    {
        if (VoteManager.Instance != null)
        {
            int[] currentVotes = VoteManager.Instance.GetAllVotes();
            UpdateChart(currentVotes);
        }
    
    }

    void Update()
    {
        // dataTimer zählt nach unten
        dataTimer -= Time.deltaTime;

        if (timerDisplay != null)
        {
            float displayValue = Mathf.Max(0, dataTimer);
            timerDisplay.text = "Return in: " + displayValue.ToString("F0") + "s";
        }

        if (dataTimer <= 0f)
        {
            ReturnToInputScene();
        }

        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            dataTimer = maxIdleTime;
        }
    }

    public void UpdateChart(int[] values)
    {
        float maxBarHeight = 200f;
        
        for (int i = 0; i < bars.Length && i < values.Length; i++)
        {
            bars[i].rectTransform.pivot = new Vector2(0.5f, 0f);

            bars[i].rectTransform.sizeDelta = new Vector2(
                bars[i].rectTransform.sizeDelta.x,
                (values[i] / 10f) * maxBarHeight 
            );

            bars[i].rectTransform.anchorMin = new Vector2(bars[i].rectTransform.anchorMin.x, 0f);
            bars[i].rectTransform.anchorMax = new Vector2(bars[i].rectTransform.anchorMax.x, 0f);
        }
    }

    public void ReturnToInputScene()
    {
        
        dataTimer = 0f; 

        if (!string.IsNullOrEmpty("InputTest"))
        {
            SceneManager.LoadScene("InputTest");
        }
    }
}