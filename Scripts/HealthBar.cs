﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public void DisplayHealthBar(Text _textLife, float _life)
    {
        _textLife.text = "Количество жизни = " + _life;
    }
}
