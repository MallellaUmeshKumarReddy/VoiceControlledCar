using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {  get; private set; } 

    public GameObject gameOverPanel;
    public GameObject gameStartPanel;

    public TextMeshProUGUI gameOverText;
    private int buildIndex;

    [SerializeField] private Button reStartButton;
    [SerializeField] private Button startButton;

    private void Awake()
    {
        Instance = this;

        gameOverPanel.SetActive(false);
        gameOverText.text = "";
        gameStartPanel.SetActive(true);
    }

    private void Start()
    {
        reStartButton.onClick.AddListener(() =>
        {
            RestartMethod();

        });

        startButton.onClick.AddListener(() =>
        {
            gameOverPanel.SetActive(false);
            gameStartPanel.SetActive(false);
            RaceManager.Instance.currentState = State.IsPlaying;
        });
    }

    public void RestartMethod()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildIndex);
    }
}
