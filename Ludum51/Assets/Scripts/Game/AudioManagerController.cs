using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{
    public static AudioManagerController instance;
    public AudioSource menuTheme, gameplayTheme, endTheme;
    public AudioSource[] soundFXList;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlayMenuTheme()
    {
        menuTheme.Play();
        gameplayTheme.Stop();
        endTheme.Stop();
    }

    public void PlayGameplayTheme()
    {
        menuTheme.Stop();
        gameplayTheme.Play();
        endTheme.Stop();
    }

    public void PlayEndTheme()
    {
        menuTheme.Stop();
        gameplayTheme.Stop();
        endTheme.Play();
    }

    public void StopAllMusic()
    {
        menuTheme.Stop();
        gameplayTheme.Stop();
        endTheme.Stop();
    }

    // SOUND FX PLAYER

    public void PlaySFX(int soundPosition)
    {
        soundFXList[soundPosition].Stop();
        soundFXList[soundPosition].Play();
    }

    public void PlaySFXPitch(int soundPosition)
    {
        soundFXList[soundPosition].Stop();
        soundFXList[soundPosition].pitch = Random.Range(0.8f, 1.2f);
        soundFXList[soundPosition].Play();
    }

    public void StopSFX( int soundPosition)
    {
        soundFXList[soundPosition].Stop();
    }
}
