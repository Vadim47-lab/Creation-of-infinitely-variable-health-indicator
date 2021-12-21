using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private Health _health;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private void Start()
    {
        Display();
    }

    private void Increase()
    {
        Display();
    }

    private void Decrease()
    {
        Display();
    }

    private void Display()
    {
        _slider.value = _health.HealthPlayer;

        _textHealth.text = "Количество жизни = " + _health.HealthPlayer;
    }
}