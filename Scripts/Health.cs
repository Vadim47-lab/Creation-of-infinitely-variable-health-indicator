using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _extensionLife;
    [SerializeField] private Button _shrinkingLife;
    [SerializeField] private Text _textLife;
    [SerializeField] private float _minLife;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _life = 100;
    [SerializeField] private int _difference = 10;

    private HealthBar _healthBar;

    private void Start()
    {
        _healthBar = gameObject.AddComponent<HealthBar>();

        _extensionLife.onClick.AddListener(Increase);
        _shrinkingLife.onClick.AddListener(Decrease);
    }

    private void Increase()
    {
        _life = Mathf.MoveTowards(_life, _maxLife, _difference);
        _slider.value = _life;

        if (_life > _maxLife)
        {
            _life = _maxLife;
            _slider.value = _life;
        }

        _healthBar.DisplayHealthBar(_textLife, _life);
    }

    private void Decrease()
    {
        _life = Mathf.MoveTowards(_life, _minLife, _difference);
        _slider.value = _life;

        if (_life < _minLife)
        {
            _life += _difference;
            _slider.value = _life;
        }

        _healthBar.DisplayHealthBar(_textLife, _life);
    }
}