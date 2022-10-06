using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public void PlayPlayerStepsSFX()
    {
        AudioManagerController.instance.PlaySFXPitch(0);
    }

    public void PlayStepsSFX()
    {
        AudioManagerController.instance.PlaySFXPitch(5);
    }
}
