using System.Collections;
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

    public float HealthPlayer { get; private set; }

    private void Start()
    {
        Increase();
        Decrease();
    }

    public void Increase()
    {
        eventDisplay();

        StartCoroutine(ChangeHealth(_maxHealth));

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }
    }

    public void Decrease()
    {
        eventDisplay();

        StartCoroutine(ChangeHealth(_minHealth));

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer += _difference;
        }
    }

    public IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (HealthPlayer != change)
        {
            HealthPlayer = Mathf.MoveTowards(HealthPlayer, change, HealthPlayer + _difference);

            yield return waitForOneSeconds;
        }
    }
}