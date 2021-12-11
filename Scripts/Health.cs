using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _minHealth;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _difference = 10;

    public UnityAction healthСhangeEvent;
    public Button icrease;
    public Button decrease;

    public float HealthPlayer { get; private set; }

    private void Start()
    {
        Icrease();
        Decrease();
    }

    private void Icrease()
    {
        healthСhangeEvent.Invoke();

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }
    }

    private void Decrease()
    {
        healthСhangeEvent.Invoke();

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer += _difference;
        }
    }
}