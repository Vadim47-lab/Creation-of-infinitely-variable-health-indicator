using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _icrease;
    [SerializeField] private Button _decrease;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private readonly UnityAction _change;
    public float _health = 100;

    private void OnEnable()
    {
        _icrease.onClick.AddListener(Icrease);
        _decrease.onClick.AddListener(Decrease);
    }

    private void OnDisable()
    {
        _icrease.onClick.RemoveListener(Icrease);
        _decrease.onClick.RemoveListener(Decrease);
    }

    private void Icrease()
    {
        _change.Invoke();

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Decrease()
    {
        _change.Invoke();

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }
}