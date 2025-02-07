using KKSpeech;
using UnityEngine;
using UnityEngine.UI;

public class SpeechCommandListener : MonoBehaviour
{
    public RecordingCanvas recordingCanvas;

    private CarController car;
    private RaceManager raceManager; 

    void Start()
    {
        car = FindObjectOfType<CarController>();

        raceManager = RaceManager.Instance;

        if (recordingCanvas == null)
        {
            recordingCanvas = FindObjectOfType<RecordingCanvas>();
        }
    }

    void Update()
    {
        if (recordingCanvas != null && car != null && raceManager.currentState == State.IsPlaying)
        {
            string recognizedText = recordingCanvas.resultText.text.ToLower();

            car.SetMovement(recognizedText);
        }
    }

    public void StopListening()
    {
        SpeechRecognizer.StopIfRecording();
    }
}
