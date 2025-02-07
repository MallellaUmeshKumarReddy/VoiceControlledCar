**VoiceControlledCar**
This project is an Android-based racing game developed as part of an assignment. The game allows the player to control a car using voice commands. The player speaks a specific word ("Go") to make the car move forward on a 2D racetrack. The objective is to complete the race before the time runs out (60 seconds).

**How It Works**

1. The game starts in the Start state. Once you press the button, it moves to IsPlaying state, and the car starts listening.
2. When you say "go" the car moves forward.
3. The speech recognition runs continuously so you don’t have to restart it after every command.
   
**Challenges Faced**

One big challenge was making sure the speech recognition keeps listening without stopping. If it stopped after every word, the experience would not feel smooth. Fixing this took quite some time, but now it works properly and listens non-stop while in the game.

**What I Used** 

1. Unity (Game Engine) – To build and manage the game.
2. KKSpeech Plugin – For speech recognition to process voice commands.
3. C# (Programming Language) – For scripting and game logic.
4. TextMeshPro – For displaying speech results on screen.
5. Unity UI – For buttons and user interface.
6. Android Microphone Permission – To request access to the microphone for speech recognition.

**How to Use**

Install the APK on your Android phone .
Give microphone permission when asked.
Start the game and speak commands to control the car!
