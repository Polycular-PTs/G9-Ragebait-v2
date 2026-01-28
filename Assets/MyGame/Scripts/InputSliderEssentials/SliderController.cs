using UnityEngine;

public class SliderController : MonoBehaviour
{
    [Header("References")]
    public Transform sliderHandle;
    public Transform barScale;
    public Vector3 centerPosition = Vector3.zero;

    [Header("Slider Settings")]
    public int maxStepsPerDirection = 5;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A; 

    private float stepDistance;
    private int currentStep = 0;

    void Start()
    {
        float lineLength = barScale.localScale.x;
        stepDistance = (lineLength / 2f) / maxStepsPerDirection;
        UpdateSliderPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(moveRightKey))
            Move(1);
        if (Input.GetKeyDown(moveLeftKey))
            Move(-1); 
    }

    private void Move(int step)
    {
        currentStep = Mathf.Clamp(currentStep + step, -maxStepsPerDirection, maxStepsPerDirection);
        UpdateSliderPosition();
    }

    private void UpdateSliderPosition()
    {
        sliderHandle.position = centerPosition + Vector3.right * (currentStep * stepDistance);
    }

    public void SetStep(int step)
    {
        currentStep = Mathf.Clamp(step, -maxStepsPerDirection, maxStepsPerDirection);
        UpdateSliderPosition();
    }

    public int GetCurrentStep() => currentStep;
}
