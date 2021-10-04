using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviourSingleton<SoundController>
{
    public enum Sounds
    {
        
    }

    public enum Songs
    {
        
    }

    bool dayMusicOn = true;

    [SerializeField] float volumeIncreaseDuration = 1f;

    [SerializeField] AudioSource[] musicSources = null;

    int currentSong = 0;

    public AudioClip[] sfx;

    [Header("Sound Options")]
    public bool soundOn = true;
    private void Start()
    {
        ChangeGameplaySong();   
    }

    public void ChangeGameplaySong()
    {
        if((currentSong - 1)>=0) musicSources[currentSong-1].Stop();
        musicSources[currentSong].Play();
        musicSources[currentSong].volume = 0;
        StartCoroutine(FadeIn(musicSources[currentSong]));
        currentSong++;
    }


    public void PlaySound(Sounds sound)
    {
        if (soundOn)
            AudioSource.PlayClipAtPoint(sfx[(int)sound], Vector3.zero);
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
    }

    IEnumerator FadeIn(AudioSource source)
    {
        while (source.volume < 1f)
        {
            float addedValue = 1f / (volumeIncreaseDuration / Time.deltaTime);
            source.volume += addedValue;

            yield return null;
        }
    }
}
