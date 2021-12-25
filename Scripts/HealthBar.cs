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

    public void Increase()
    {
        StartCoroutine(ChangeHealth(_maxHealth));

        Display();
    }

    public void Decrease()
    {
        StartCoroutine(ChangeHealth(_minHealth));

        Display();
    }

    private void Display()
    {
        _slider.value = _health.HealthPlayer;

        Debug.Log(_slider.value);

        _textHealth.text = "Количество жизни = " + _health.HealthPlayer;

        Debug.Log(_textHealth.text);
    }

    private IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health.HealthPlayer != change)
        {
            _slider.value = Mathf.MoveTowards(_health.HealthPlayer, change, _health.HealthPlayer + _difference);

            yield return waitForOneSeconds;
        }
    }
}