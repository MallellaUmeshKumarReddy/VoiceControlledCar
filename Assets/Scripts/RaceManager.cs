using UnityEngine;
using UnityEngine.SceneManagement;


public enum State
{
    Start,
    IsPlaying,
    GameOver,
}

public class RaceManager : MonoBehaviour
{

    public static RaceManager Instance { get; private set; }

    [SerializeField] private CarController carController;
    [SerializeField] private SpeechCommandListener speechCommandListener;

    public State currentState;


    private void Awake()
    {
        Instance = this;
        currentState = State.Start;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Start:
                break; 
            case State.IsPlaying:
                break; 
            case State.GameOver:

                UIManager.Instance.gameOverPanel.SetActive(true);   

                break; 
            default:
                Debug.LogWarning("Unexpected game state!");
                break;
        }
    }

    public void FinishRace()
    {
        // Stop car movement
       // carController.StopCar();

        speechCommandListener.StopListening();

        //Debug.Log("Race Finished!");

        UIManager.Instance.gameOverText.text = "You Won";

        RaceManager.Instance.currentState = State.GameOver;

    }


   

}

