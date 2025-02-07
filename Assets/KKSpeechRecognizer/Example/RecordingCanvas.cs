using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using KKSpeech;
using UnityEngine.Android;
using TMPro;

public class RecordingCanvas : MonoBehaviour
{
    public TextMeshProUGUI resultText; 

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }

        if (SpeechRecognizer.ExistsOnDevice())
        {
            SpeechRecognizerListener listener = GameObject.FindObjectOfType<SpeechRecognizerListener>();
            listener.onAuthorizationStatusFetched.AddListener(OnAuthorizationStatusFetched);
            listener.onAvailabilityChanged.AddListener(OnAvailabilityChange);
            listener.onErrorDuringRecording.AddListener(OnError);
            listener.onErrorOnStartRecording.AddListener(OnError);
            listener.onFinalResults.AddListener(OnFinalResult);
            listener.onPartialResults.AddListener(OnPartialResult);
            listener.onEndOfSpeech.AddListener(OnEndOfSpeech);

            SpeechRecognizer.RequestAccess();

            // Start listening as soon as the app starts
            StartListening();
        }
        else
        {
            resultText.text = "Sorry, but this device doesn't support speech recognition";
        }
    }

    void Update()
    {
        if (RaceManager.Instance.currentState == State.IsPlaying && !SpeechRecognizer.IsRecording())
        {
            StartListening();
        }
    }



    // Starts speech recognition and listens continuously
    private void StartListening()
    {
        if (RaceManager.Instance.currentState == State.IsPlaying)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Debug.LogError("Microphone permission not granted!");
                resultText.text = "Microphone permission required!";
                Permission.RequestUserPermission(Permission.Microphone);
                return;
            }

            if (!SpeechRecognizer.IsRecording())
            {
                SpeechRecognizer.StartRecording(true); // true indicates continuous recognition
                resultText.text = "Listening...";
            }
        }

    }

    public void OnFinalResult(string result)
    {
        resultText.text = result;

        // Process the command to control the car's speed and movement
        CarController carController = FindObjectOfType<CarController>();
        if (carController != null)
        {
            carController.SetMovement(result);
        }

        // Introduce a small delay before restarting listening
        StartCoroutine(RestartListening());
    }

    private IEnumerator RestartListening()
    {
        yield return new WaitForSeconds(0.1f); // Small delay to avoid conflicts
        StartListening();
    }

    public void OnPartialResult(string result)
    {
        resultText.text = result; // Display the partial result while speaking
    }

    public void OnAvailabilityChange(bool available)
    {
        resultText.text = available ? "Listening..." : "Speech Recognition not available";
    }

    public void OnAuthorizationStatusFetched(AuthorizationStatus status)
    {
        if (status == AuthorizationStatus.Authorized)
        {
            // Automatically start listening once authorized
            StartListening();
        }
        else
        {
            resultText.text = "Cannot use Speech Recognition, authorization status is " + status;
        }
    }

    public void OnEndOfSpeech()
    {
        resultText.text = "End of speech";

        // Restart listening after speech ends
        StartListening();
    }

    public void OnError(string error)
    {
        Debug.LogError("Speech Recognition Error: " + error);
        resultText.text = "Error: " + error;

        // Restart listening after error
        StartListening();
    }
}
