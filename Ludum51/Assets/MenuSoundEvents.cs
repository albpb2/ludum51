using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundEvents : MonoBehaviour
{
    public void PlayMenuRollover()
    {
        AudioManagerController.instance.PlaySFX(9);
    }

    public void PlayMenuClick()
    {
        AudioManagerController.instance.PlaySFX(8);
    }
}
