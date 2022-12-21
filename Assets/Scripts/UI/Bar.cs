using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetValue(int currentValue, int maxValue)
    {
        _slider.value = (float)currentValue / maxValue;
    }
}
