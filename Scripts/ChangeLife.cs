using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLife : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Button _extensionLife;
    [SerializeField] private Button _shrinkingLife;
    [SerializeField] private Text _textLife;
    [SerializeField] private int _life = 100;
    [SerializeField] private int _difference = 10;

    public void SetNormalizedPosition(float position)
    {
        _target.position = Vector3.Lerp(_extensionLife.position, _shrinkingLife.position, position);
    }

    private void Update()
    {
        _textLife.text = "Количество жизни = " + _life;
    }

    private void Start()
    {
        _extensionLife.onClick.AddListener(ExtensionLife);
        _shrinkingLife.onClick.AddListener(ShrinkingLife);
    }

    private void ExtensionLife()
    {
        _target.position = Vector3.Lerp(_extensionLife.position, _shrinkingLife.position, _life += _difference);
    }

    private void ShrinkingLife()
    {
        _target.position = Vector3.Lerp(_extensionLife.position, _shrinkingLife.position, _life -= _difference);
    }
}