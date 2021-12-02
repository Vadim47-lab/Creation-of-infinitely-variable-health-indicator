using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public void DisplayHealthBar(float _health)
    {
        _textHealth.text = "Количество жизни = " + _health;
    }

    public void Increase(float _health)
    {
        StartCoroutine(IncreaseHealth(_health));
    }

    public void Decrease(float _health)
    {
        StartCoroutine(DecreaseVolume(_health));
    }

    public IEnumerator IncreaseHealth(float _health)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != _maxHealth)
        {
            _slider.value = _health;

            _health = Mathf.MoveTowards(_health, _maxHealth, _health + _difference);

            yield return waitForOneSeconds;
        }
    }

    public IEnumerator DecreaseVolume(float _health)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != _minHealth)
        {
            _slider.value = _health;

            _health = Mathf.MoveTowards(_health, _minHealth, _health - _difference);

            yield return waitForOneSeconds;
        }
    }
}