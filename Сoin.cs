using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Сoin : MonoBehaviour
{
    [SerializeField] private GameObject _coin;

    private CoinsCounter _сoinsCounter;

    private void Start()
    {
        _сoinsCounter = gameObject.AddComponent<CoinsCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _сoinsCounter.countingСoins();
        }

        _coin.SetActive(false);
    }
}