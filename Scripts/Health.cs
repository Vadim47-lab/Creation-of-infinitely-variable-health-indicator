using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityAction Change;
    [SerializeField] private Button _increase;
    [SerializeField] private Button _decrease;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private float _health;

    private void Start()
    {
        Increase();
        Decrease();
    }

    public void Increase()
    {
        Change?.Invoke();

        StartCoroutine(_healthBar.ChangeHealth(_maxHealth));

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Decrease()
    {
        Change?.Invoke();

        StartCoroutine(_healthBar.ChangeHealth(_minHealth));

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }
}