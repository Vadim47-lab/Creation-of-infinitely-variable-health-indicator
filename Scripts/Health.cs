using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public UnityAction healthСhangeEvent;
    public Button increase;
    public Button decrease;

    public float HealthPlayer { get; set; }

    private void Start()
    {
        HealthPlayer = 100;

        increase = GetComponent<Button>();
        decrease = GetComponent<Button>();
        increase.onClick.AddListener(healthСhangeEvent);
        decrease.onClick.AddListener(healthСhangeEvent);
    }
}