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
    [SerializeField] private int _difference;

    private void Start()
    {
        Display();
    }

    private void OnEnable()
    {
        _health.Changed += Increase;
        _health.Changed += Decrease;
    }

    private void OnDisable()
    {
        _health.Changed -= Increase;
        _health.Changed -= Decrease;
    }

    private void Increase()
    {
        StopCoroutine(ChangeHealth(_minHealth));

        StartCoroutine(ChangeHealth(_maxHealth));

        Display();
    }

    private void Decrease()
    {
        StopCoroutine(ChangeHealth(_maxHealth));

        StartCoroutine(ChangeHealth(_minHealth));

        Display();
    }

    private void Display()
    {
        _textHealth.text = "Количество жизни = " + _health.Value;
    }

    private IEnumerator ChangeHealth(float change)
    {
        var wait = new WaitForSeconds(1f);

        while (_health.Value != change)
        {
            _slider.value = Mathf.MoveTowards(_health.Value, change, _health.Value + _difference);

            yield return wait;
        }
    }
}