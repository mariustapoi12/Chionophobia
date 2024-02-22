using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] sounds; // Array of sound clips
    public float minVolume = 0.0f; // Minimum volume
    public float maxVolume = 1.0f; // Maximum volume
    public float duration = 60.0f; // Duration for volume increase in seconds
    public AudioSource audioSource; // Reference to the AudioSource component

    private float startTime; // Time when the script started
    private float realTimeSinceStartOfScript;
    private float delay; // Delay between sounds in seconds

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on the GameObject. Please attach an AudioSource component.");
            return;
        }

        if (sounds.Length == 0)
        {
            Debug.LogError("No audio clips assigned to the 'sounds' array.");
            return;
        }

        // Set the initial volume
        audioSource.volume = minVolume;

        // Play initial random sound
        PlayRandomSound();

        startTime = Time.time;

        realTimeSinceStartOfScript = Time.time;
    }

    void Update()
    {
        // Calculate the elapsed time since the script started
        float elapsedTime = Time.time - startTime;
        float elapsedTimeSinceRealTimeStartOfScript = Time.time - realTimeSinceStartOfScript;

        audioSource.volume = Mathf.Min(elapsedTimeSinceRealTimeStartOfScript / 500, 0.05f);

        // Check if the duration has passed, and play a new random sound
        if (elapsedTime >= delay)
        {
            PlayRandomSound();
            startTime = Time.time;
        }
    }

    void PlayRandomSound()
    {
        // Choose a random sound from the array
        AudioClip randomSound = sounds[Random.Range(0, sounds.Length)];

        // Assign the chosen sound to the AudioSource
        audioSource.clip = randomSound;

        delay = randomSound.length + 3.0f;

        // Play the sound
        audioSource.Play();
    }
}