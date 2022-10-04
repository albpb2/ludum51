using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerController : MonoBehaviour
{
    public static AudioManagerController instance;
    [Header("Music Settings")]
    public AudioSource menuTheme;
    public AudioSource gameplayTheme;
    public AudioSource endTheme;

    [Header("Alarm Sounds")]
    public AudioSource tenSecondsAlarm;
    public AudioSource fiveSecondsAlarm;
    public AudioSource threeSecondsAlarm;

    [Header("SFX Sounds")]
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


    // ALARM

    public void PlayTenSecondsAlarm()
    {
        threeSecondsAlarm.Stop();
        fiveSecondsAlarm.Stop();
        tenSecondsAlarm.Play();
    }

    public void PlayFiveSecondsAlarm()
    {
        threeSecondsAlarm.Stop();
        fiveSecondsAlarm.Play();
        tenSecondsAlarm.Stop();
    }

    public void PlayThreeSecondsAlarm()
    {
        threeSecondsAlarm.Play();
        fiveSecondsAlarm.Stop();
        tenSecondsAlarm.Stop();
    }

    public void StopAllAlarm()
    {
        threeSecondsAlarm.Stop();
        fiveSecondsAlarm.Stop();
        tenSecondsAlarm.Stop();
    }

    public void PauseAllAlarm()
    {
        threeSecondsAlarm.Pause();
        fiveSecondsAlarm.Pause();
        tenSecondsAlarm.Pause();
    }


}
