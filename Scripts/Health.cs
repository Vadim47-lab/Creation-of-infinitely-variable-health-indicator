using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _increase;
    [SerializeField] private Button _decrease;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private float _health;
    public event UnityAction Changed;

    public void Increase()
    {
        Changed?.Invoke();

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Decrease()
    {
        Changed?.Invoke();

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }
}