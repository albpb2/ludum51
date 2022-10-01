using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillEnemyHealthBar : MonoBehaviour
{
    public NavMeshEnemyController enemy;
    public Image fillImage;
    public Slider slider;

    public void FillEnemySliderValue()
    {
        fillImage.enabled = true;
        float fillValue = (float)enemy.HP / (float)enemy.HpMax;
        slider.value = fillValue;
        Debug.Log($"enemy hp: {enemy.HP} hpMax: {enemy.HpMax}");

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        Debug.Log($"Slider.Value: {slider.value} Slider.MaxValue: {slider.maxValue}");
        if (slider.value <= slider.maxValue * 0.2f)
        {
            fillImage.color = Color.red;
        }
        else if (slider.value <= slider.maxValue * 0.5f)
        {
            fillImage.color = Color.yellow;
        }else
        {
            fillImage.color = Color.green;
        }
    }

    public void ModifySliderMaxValue(int value) 
    {
        slider.maxValue = value; 
    }
}
