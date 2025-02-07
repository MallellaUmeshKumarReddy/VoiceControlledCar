using UnityEngine;

public class Timer : MonoBehaviour
{
    public float maxTime;

    public float timer;

    private void Awake()
    {
        timer = maxTime;
    }

    private void Update()
    {
        if(RaceManager.Instance.currentState == State.IsPlaying)
        {

            timer -= Time.deltaTime;

            if(timer <=0)
            {
                timer = 0;
                Debug.Log("GameOver Times UP!");
                UIManager.Instance.gameOverText.text = "Time's UP!";
                RaceManager.Instance.currentState = State.GameOver;
            }

        }
    }

}
