using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumeController : MonoBehaviour
{
    private const float volumeChangeStep = .05f;

    [SerializeField] string _audioMixerGroupVolumeName;
    [SerializeField] private AudioMixer _audioMixer;

    public void IncreaseVolume()
    {
        _audioMixer.GetFloat(_audioMixerGroupVolumeName, out var currentVolume);
        currentVolume = Mathf.Pow(10, currentVolume / 20);
        var newVolume = Mathf.Min(1, currentVolume + volumeChangeStep);
        Debug.Log($"Volume: {newVolume}");
        newVolume = Mathf.Log10(newVolume) * 20;
        _audioMixer.SetFloat(_audioMixerGroupVolumeName, newVolume);
    }

    public void ReduceVolume()
    {
        _audioMixer.GetFloat(_audioMixerGroupVolumeName, out var currentVolume);
        currentVolume = Mathf.Pow(10, currentVolume / 20);
        var newVolume = Mathf.Max(.00001f, currentVolume - volumeChangeStep);
        Debug.Log($"Volume: {newVolume}");
        newVolume = Mathf.Log10(newVolume) * 20;
        _audioMixer.SetFloat(_audioMixerGroupVolumeName, newVolume);
    }
}