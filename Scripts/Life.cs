using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Button _extensionLife;
    [SerializeField] private Button _shrinkingLife;
    [SerializeField] private float _minLife;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _life = 100;
    [SerializeField] private int _difference = 10;

    private LifeBar _lifeBar;

    private void Start()
    {
        _lifeBar = gameObject.AddComponent<LifeBar>();

        _extensionLife.onClick.AddListener(Increase);
        _shrinkingLife.onClick.AddListener(Decrease);
    }

    private void Increase()
    {
        _lifeBar.IncreaseLife(ref _life, _maxLife, _difference);
        _slider.value = _life;

        if (_life > _maxLife)
        {
            _life = _maxLife;
            _slider.value = _life;
        }

        _lifeBar.DisplayHealthBar(_life);
    }

    private void Decrease()
    {
        _lifeBar.DecreaseLife(ref _life, _minLife, _difference);
        _slider.value = _life;

        if (_life < _minLife)
        {
            _life += _difference;
            _slider.value = _life;
        }

        _lifeBar.DisplayHealthBar(_life);
    }
}