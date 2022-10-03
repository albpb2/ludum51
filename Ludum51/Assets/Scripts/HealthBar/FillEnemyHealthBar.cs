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
            fillImage.color = new Color(0.5849056f, 0.234514f, 0.234514f); //Red
        }
        else if (slider.value <= slider.maxValue * 0.5f)
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
