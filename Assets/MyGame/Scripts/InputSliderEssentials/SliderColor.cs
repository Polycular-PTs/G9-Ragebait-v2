using UnityEngine;

public class SliderColor : MonoBehaviour
{
    public GameObject sliderObject;
    public Gradient colorGradient;
    public float minX;
    public float maxX;

    private SpriteRenderer renderTarget;

    private void Start()
    {
        renderTarget = sliderObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float normalizedValue = Mathf.InverseLerp(minX, maxX, sliderObject.transform.position.x);
        renderTarget.color = colorGradient.Evaluate(normalizedValue);

    }
}