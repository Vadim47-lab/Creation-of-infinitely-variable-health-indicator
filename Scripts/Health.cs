using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Button _extensionLife;
    [SerializeField] private Button _shrinkingLife;
    [SerializeField] private Text _textLife;
    [SerializeField] private float _target;
    [SerializeField] private float _currentStrength;
    [SerializeField] private float _maxStrength;
    [SerializeField] private int _life = 100;
    [SerializeField] private int _difference = 10;

    private readonly Display _display;

    private void Update()
    {
        _display.Update(_textLife, _life);
    }

    private void Start()
    {
        _extensionLife.onClick.AddListener(ExtensionLife);
        _shrinkingLife.onClick.AddListener(ShrinkingLife);
    }

    private void ExtensionLife()
    {
        _target = Mathf.MoveTowards(_maxStrength, _currentStrength, _life += _difference);
       
        if (_life > 100)
        {
            _life -= _difference;
        }
    }

    private void ShrinkingLife()
    {
        _target = Mathf.MoveTowards(_maxStrength, _currentStrength, _life -= _difference);

        if (_life < 0)
        {
            _life += _difference;
        }
    }
}

public class Display
{
    public void Update(Text _textLife, int _life)
    {
        _textLife.text = "Количество жизни = " + _life;
    }
}