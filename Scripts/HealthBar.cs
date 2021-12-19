using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private Health _health;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    private void Start()
    {
        Display();
    }

    private void Increase()
    {
        StartCoroutine(ChangeHealth(_maxHealth));

        Display();
    }

    private void Decrease()
    {
        StartCoroutine(ChangeHealth(_minHealth));

        Display();
    }

    private void Display()
    {
        _slider.value = _health._health;

        _textHealth.text = "Количество жизни = " + _health._health;
    }

    private IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health._health != change)
        {
            _health._health = Mathf.MoveTowards(_health._health, change, _health._health + _difference);

            yield return waitForOneSeconds;
        }
    }
}