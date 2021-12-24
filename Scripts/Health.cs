using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _increase;
    [SerializeField] private Button _decrease;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private readonly HealthBar _healthBar;
    public event UnityAction Changed;

    public float HealthPlayer { get; private set; }

    public void Increase()
    {
        HealthPlayer += _difference;

        Changed += _healthBar.Increase;

        Changed?.Invoke();

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }
    }

    public void Decrease()
    {
        HealthPlayer -= _difference;

        Changed += _healthBar.Decrease;

        Changed?.Invoke();

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer = _minHealth;
        }
    }
}