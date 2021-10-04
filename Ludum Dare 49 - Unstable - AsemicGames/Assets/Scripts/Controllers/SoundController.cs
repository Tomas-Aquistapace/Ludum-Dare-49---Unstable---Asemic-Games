using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviourSingleton<SoundController>
{
    public enum Sounds
    {
        easter_egg,
        die_a,
        die_b,
        die_c,
        level_end,
        level_start,
        switch_circulo,
        switch_deca,
        switch_triangulo,
        walk_blocked_a,
        walk_blocked_b,
        walk_blocked_c,
        walk_circulo_a,
        walk_circulo_b,
        walk_deca_a,
        walk_deca_b,
        walk_triangulo_a,
        walk_triangulo_b,
        transition
    }

    public enum Songs
    {
        music_final,
        music_menu
    }

    [SerializeField] float volumeIncreaseDuration = 1f;

    [SerializeField] AudioSource[] musicSources = null;

    public AudioClip[] sfx;

    [Header("Sound Options")]
    public bool soundOn = true;

    public void PlayGameplaySong()
    {
        musicSources[(int)Songs.music_final].Play();
    }

    public void PlayMenuSong()
    {
        musicSources[(int)Songs.music_menu].Play();
    }

    public void StopMusic()
    {
        foreach (AudioSource music in musicSources)
        {
            music.Stop();
        }
    }

    public void PlaySound(Sounds sound)
    {
        if (soundOn)
            AudioSource.PlayClipAtPoint(sfx[(int)sound], Vector3.zero, 1);
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
