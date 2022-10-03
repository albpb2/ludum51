using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
   // public PlayerController playerController;
    [SerializeField] Image fillImage;
    [SerializeField] Slider slider;
    [SerializeField] NavMeshAgentController navMeshAgentController;

    // Start is called before the first frame update
    void awake()
    {
        slider.maxValue = navMeshAgentController.HpMax;
        FillSliderValue();
    }
    
    public void FillSliderValue()
    {
        float fillValue = (float)navMeshAgentController.HP / (float)navMeshAgentController.HpMax;
        slider.value = fillValue;
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value <= slider.maxValue * 0.2f)
        {
            fillImage.color = new Color(0.5849056f, 0.234514f, 0.234514f); //Red
        }else if (slider.value <= slider.maxValue * 0.4f)
        {
            fillImage.color = new Color(0.5849056f, 0.234514f, 0.234514f); //Red
        }
        else
        {
            fillImage.color = new Color(0.8196079f, 0.4588236f, 0.2745098f); //Orange
        }
    }

    public void ModifySliderMaxValue(int value) 
    {
        slider.maxValue = value; 
    }
}
