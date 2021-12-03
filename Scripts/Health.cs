using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _change;
    [SerializeField] private float _health = 100;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public void Increase()
    {
        _change.Invoke();

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Decrease()
    {
        _change.Invoke();

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }
}