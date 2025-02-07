using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private Timer timer;

    [SerializeField] private Image timerImage;

    private void Awake()
    {
        timer = GetComponentInParent<Timer>();
        timerImage = GetComponentInParent<Image>();
    }

    private void Update()
    {
        if (timer != null && timerImage != null)
        {
            float fillAmount = timer.timer / timer.maxTime;  

            timerImage.fillAmount = fillAmount;
        }
    }
}
