using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityAction _change;
    [SerializeField] private UnityAction _increase;
    [SerializeField] private UnityAction _decrease;
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _extension;
    [SerializeField] private Button _shrinking;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private void OnEnable()
    {
        _extension.onClick.AddListener(Increase);
        _shrinking.onClick.AddListener(Decrease);
    }

    private void OnDisable()
    {
        _extension.onClick.AddListener(Increase);
        _shrinking.onClick.AddListener(Decrease);
    }

    private void Increase()
    {
        _change.Invoke();

        _slider.value = _health;

        _increase.Invoke();

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
            _slider.value = _health;
        }
    }

    private void Decrease()
    {
        _change.Invoke();

        _slider.value = _health;

        _decrease.Invoke();

        if (_health < _minHealth)
        {
            _health += _difference;
            _slider.value = _health;
        }
    }
}