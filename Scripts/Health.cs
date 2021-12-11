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
    public Button increase;
    public Button decrease;

    public float HealthPlayer { get; set; }

    private void Start()
    {
        increase = GetComponent<Button>();
        decrease = GetComponent<Button>();
        healthСhangeEvent += Increase;
        increase.onClick.AddListener(healthСhangeEvent);
        healthСhangeEvent += Decrease;
        decrease.onClick.AddListener(healthСhangeEvent);
        //Increase();
        //Decrease();
    }

    private void Increase()
    {
        healthСhangeEvent();

        if (HealthPlayer > _maxHealth)
        {
            HealthPlayer = _maxHealth;
        }
    }

    private void Decrease()
    {
        healthСhangeEvent();

        if (HealthPlayer < _minHealth)
        {
            HealthPlayer += _difference;
        }
    }
}