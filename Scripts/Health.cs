using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public UnityAction _eventChange;
    public Button _icrease;
    public Button _decrease;
    public float _health = 100;

    public void Start()
    {
        Icrease();
        Decrease();
    }

    private void Icrease()
    {
        _eventChange.Invoke();

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private void Decrease()
    {
        _eventChange.Invoke();

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }
}