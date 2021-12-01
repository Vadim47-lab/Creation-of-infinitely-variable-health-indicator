using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private int _difference = 10;

    public void DisplayHealthBar(float _health)
    {
        _textHealth.text = "Количество жизни = " + _health;
    }

    private IEnumerator IncreaseHealth(float _health, float _maxHealth)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != _maxHealth)
        {
            _health = Mathf.MoveTowards(_health, _maxHealth, _health + _difference);

            yield return waitForOneSeconds;
        }
    }

    private IEnumerator DecreaseVolume(float _health, float _minHealth)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health != _minHealth)
        {
            _health = Mathf.MoveTowards(_health, _minHealth, _health - _difference);

            yield return waitForOneSeconds;
        }
    }
}