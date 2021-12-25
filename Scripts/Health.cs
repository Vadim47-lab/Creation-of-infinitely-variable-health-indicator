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
    [SerializeField] private int _difference;

    public event UnityAction Changed;

    public float HealthPlayer { get; private set; }

    private void Start()
    {
        HealthPlayer = _maxHealth;
    }

    public void Increase()
    {
        HealthPlayer += _difference;

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }

        Changed?.Invoke();
    }

    public void Decrease()
    {
        HealthPlayer -= _difference;

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer = _minHealth;
        }

        Changed?.Invoke();
    }
}