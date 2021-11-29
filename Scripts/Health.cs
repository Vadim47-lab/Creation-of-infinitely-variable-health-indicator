using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _extensionHealth;
    [SerializeField] private Button _shrinkingHealth;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private SliderBar _sliderBar;

    private void Start()
    {
        _sliderBar = gameObject.AddComponent<SliderBar>();
    }

    private void OnEnable()
    {
        _extensionHealth.onClick.AddListener(Increase);
        _shrinkingHealth.onClick.AddListener(Decrease);
    }

    private void OnDisable()
    {
        _extensionHealth.onClick.AddListener(Increase);
        _shrinkingHealth.onClick.AddListener(Decrease);
    }

    private void Increase()
    {
        _sliderBar.DisplayHealthBar(_health);
        IncreaseHealth();
    }

    private void Decrease()
    {
        _sliderBar.DisplayHealthBar(_health);
        DecreaseHealth();
    }

    public void IncreaseHealth()
    {
        _slider.value = _health;

        _health = Mathf.MoveTowards(_health, _maxHealth, _health + _difference);

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
            _slider.value = _health;
        }
    }

    public void DecreaseHealth()
    {
        _slider.value = _health;

        _health = Mathf.MoveTowards(_health, _minHealth, _health - _difference);

        if (_health < _minHealth)
        {
            _health += _difference;
            _slider.value = _health;
        }
    }
}