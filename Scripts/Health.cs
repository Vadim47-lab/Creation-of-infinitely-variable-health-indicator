using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private UnityEvent _displayHealthBar;
    [SerializeField] private UnityEvent _increaseHealthBar;
    [SerializeField] private UnityEvent _decreaseHealthBar;
    [SerializeField] private Button _extensionHealth;
    [SerializeField] private Button _shrinkingHealth;
    [SerializeField] private float _health = 100;

    private void Start()
    {
        _extensionHealth.onClick.AddListener(Increase);
        _shrinkingHealth.onClick.AddListener(Decrease);
    }

    private void Increase()
    {
        _displayHealthBar?.Invoke();
        _increaseHealthBar?.Invoke();
    }

    private void Decrease()
    {
        _displayHealthBar?.Invoke();
        _decreaseHealthBar?.Invoke();
    }
}