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
    
    private float _health;

    public void Start()
    {
        GameObject batman = GameObject.Find("Batman");
        _health = batman.GetComponent<float>();
    }

    public void Display()
    {
        _slider.value = _health;

        _textHealth.text = "Количество жизни = " + _health;
    }

    public void Increase()
    {
        StartCoroutine(IncreaseHealth());
    }

    public void Decrease()
    {
        StartCoroutine(DecreaseVolume());
    }

    public IEnumerator IncreaseHealth()
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != _maxHealth)
        {
            _slider.value = _health;

            _health = Mathf.MoveTowards(_health, _maxHealth, _health + _difference);

            yield return waitForOneSeconds;
        }
    }

    public IEnumerator DecreaseVolume()
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