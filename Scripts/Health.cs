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

    public float Value { get; private set; }

    private void Start()
    {
        Value = _maxHealth;
    }

    public void Increase()
    {
        Value += _difference;

        Value = Mathf.Clamp(Value, _minHealth, _maxHealth);

        Changed?.Invoke();
    }

    public void Decrease()
    {
        Value -= _difference;

        Value = Mathf.Clamp(Value, _minHealth, _maxHealth);

        Changed?.Invoke();
    }
}