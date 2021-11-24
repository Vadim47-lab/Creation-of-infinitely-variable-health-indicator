using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    [SerializeField] private Text _textLife;

    public void DisplayHealthBar(float _life)
    {
        _textLife.text = "Количество жизни = " + _life;
    }

    public void IncreaseLife(ref float _life, float _maxLife, float _difference)
    {
        _life = Mathf.MoveTowards(_life, _maxLife, _difference);
    }

    public void DecreaseLife(ref float _life, float _minLife, float _difference)
    {
        _life = Mathf.MoveTowards(_life, _minLife, _difference);
    }
}