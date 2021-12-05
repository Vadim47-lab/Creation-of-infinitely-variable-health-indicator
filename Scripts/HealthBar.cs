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
    [SerializeField] private GameObject _batman = Health;

    private float _health;

    public void Start()
    {
        _health = _batman.GetComponent<Health>()._health;

        Increase();
        Display();
        Decrease();
    }

    private void Display()
    {
        _slider.value = _health;

        _textHealth.text = "Количество жизни = " + _health;
    }

    private void Increase()
    {
        StartCoroutine(ChangeHealth(_maxHealth));
    }

    private void Decrease()
    {
        StartCoroutine(ChangeHealth(_minHealth));
    }

    public IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != change)
        {
            _slider.value = _health;

            _health = Mathf.MoveTowards(_health, change, _health + _difference);

            yield return waitForOneSeconds;
        }
    }
}