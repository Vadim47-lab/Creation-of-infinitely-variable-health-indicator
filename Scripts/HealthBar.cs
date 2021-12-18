using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _textHealth;
    [SerializeField] private Health _health;
    [SerializeField] private int _difference = 10;

    private void Start()
    {
        Display();
    }

    public void Display()
    {
        _slider.value = _health._health;

        _textHealth.text = "Количество жизни = " + _health._health;
    }

    public IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (_health._health != change)
        {
            _health._health = Mathf.MoveTowards(_health._health, change, _health._health + _difference);

            yield return waitForOneSeconds;
        }
    }
}