using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region @Properties
    /*
     * A reference to the Full Sound Source that has effect with all the map.
     * This GameObject is assigned via the Inspector and contains the AudioSource component that plays sounds.
     */
    [SerializeField]
    private GameObject _fullSoundSource;

    public GameObject FullSoundSource
    {
        get { return _fullSoundSource; }
    }

    /*
     * A reference to the Music Sound Source that has effect with all the map.
     * This GameObject is assigned via the Inspector and contains the AudioSource component that plays sounds.
     */
    [SerializeField]
    private GameObject _musicSource;

    public GameObject MusicSource
    {
        get { return _musicSource; }
    }

    #endregion

    #region @Public Methods

    /*
     * A method to play the coin collection sound effect.
     * This method loads an audio clip from the resources folder and plays it through the AudioSource component.
     * If the clip is not found, an error message is logged.
     * 
     * @param void - This method does not take any parameters.
     * @returns void - This method does not return any value.
     */
    public void CoinCollectSound()
    {
        // Get the AudioSource component attached to the FullSoundSource GameObject
        AudioSource audioSource = FullSoundSource.GetComponent<AudioSource>();

        // Load the coin collection sound from Resources
        AudioClip audioClip = Resources.Load<AudioClip>("sounds/coin-collect");

        // Check if the audio clip is found and then play it
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioClip non trovato.");
        }
    }


    /*
     * Toggles the playback state of the music.
     * If the AudioSource is currently playing, it stops the music.
     * If the AudioSource is not playing, it starts the music.
     * @returns void - This method does not return a value.
     */
    public void StartOrStopMusic()
    {
        AudioSource source = MusicSource.GetComponent<AudioSource>();

        if (source.isPlaying)
        {
            source.Stop();
        }
        else
        {
            source.Play();
        }
    }

    #endregion
}
