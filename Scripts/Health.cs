﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityAction eventDisplay;
    [SerializeField] private Button increase;
    [SerializeField] private Button decrease;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public float _health = 100;

    private void Start()
    {
        Increase();
        Decrease();
    }

    public void Increase()
    {
        eventDisplay();

        StartCoroutine(ChangeHealth(_maxHealth));

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    public void Decrease()
    {
        eventDisplay();

        StartCoroutine(ChangeHealth(_minHealth));

        if (_health < _minHealth)
        {
            _health += _difference;
        }
    }

    public IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != change)
        {
            _health = Mathf.MoveTowards(_health, change, _health + _difference);

            yield return waitForOneSeconds;
        }
    }
}