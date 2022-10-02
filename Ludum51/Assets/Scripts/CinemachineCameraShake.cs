using Cinemachine;
using UnityEngine;

public class CinemachineCameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera _cinemachineVirtualCamera;
    CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

    private float _remainingShakeTime;

    private void Awake()
    {
        _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cinemachineBasicMultiChannelPerlin =
            _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        if (_remainingShakeTime > 0)
        {
            _remainingShakeTime -= Time.deltaTime;
            if (_remainingShakeTime <= 0)
            {
                _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
            }
        }
    }

    public void Shake(float intensity, float duration)
    {
        _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _remainingShakeTime = duration;
    }
}
