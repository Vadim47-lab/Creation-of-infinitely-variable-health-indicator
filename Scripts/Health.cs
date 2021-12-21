using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _increase;
    [SerializeField] private Button _decrease;
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public float HealthPlayer { get; private set; }
    public event UnityAction Changed;

    public void Increase()
    {
        Changed?.Invoke();

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }
    }

    public void Decrease()
    {
        Changed?.Invoke();

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer += _difference;
        }

        StartCoroutine(ChangeHealth(HealthPlayer));
    }

    private IEnumerator ChangeHealth(float change)
    {
        var waitForOneSeconds = new WaitForSeconds(1f);

        while (HealthPlayer != change)
        {
            HealthPlayer = Mathf.MoveTowards(HealthPlayer, change, HealthPlayer + _difference);

            yield return waitForOneSeconds;
        }
    }
}