using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    private Slider ProgressBar;
    public float maxValue;
    public float startValue;

    private void Awake()
    {
        ProgressBar = GetComponent<Slider>();
        ProgressBar.maxValue = maxValue;
        ProgressBar.value = startValue;
    }

    public void changeValueTo(float Value)
    {
        ProgressBar.value = Value;
    }

    public void SetMaxValueTo(float NewMaxValue)
    {
        ProgressBar.maxValue = NewMaxValue;
    }

    public void IncreaseValue(float Amount)
    {
        ProgressBar.value += Amount;
    }

    public void DecreaseValue(float Amount)
    {
        ProgressBar.value -= Amount;
    }

    public float ReturnProgressValue()
    {
        return ProgressBar.value;
    }
}
