using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;

    public void DisplayHealthBar(float _health)
    {
        _textHealth.text = "Количество жизни = " + _health;
    }
}