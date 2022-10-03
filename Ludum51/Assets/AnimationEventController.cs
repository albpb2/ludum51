using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    public void PlayStepsSFX()
    {
        AudioManagerController.instance.PlaySFXPitch(5);
    }
}
