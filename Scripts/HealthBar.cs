using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public void DisplayHealthBar(float _health)
    {
        _textHealth.text = "Количество жизни = " + _health;
    }

    public void IncreaseLife(ref float _health)
    {
        _slider.value = _health;

        for (_health = 0; _health < _maxHealth; _health++)
        {
            _health = Mathf.MoveTowards(_health, _maxHealth, _difference);
        }

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
            _slider.value = _health;
        }
    }

    public void DecreaseLife(ref float _health)
    {
        _slider.value = _health;

        for (_health = 100; _health > _minHealth; _health--)
        {
            _health = Mathf.MoveTowards(_health, _minHealth, _difference);
        }

        if (_health < _minHealth)
        {
            _health += _difference;
            _slider.value = _health;
        }
    }
}