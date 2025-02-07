using UnityEngine;
using UnityEngine.UI;

public class SpeedMeterUI : MonoBehaviour
{
    [SerializeField] private Image speedometerUI; 
    [SerializeField] private CarController carController; 

    private float maxSpeed;

    private void Awake()
    {
        maxSpeed = carController.maxSpeed;
    }



    private void Update()
    {
        if (carController != null)
        {
            float speedPercent = Mathf.Clamp(carController.currentSpeed / maxSpeed, 0f, 1f);
            speedometerUI.fillAmount = speedPercent;
        }
    }
}
