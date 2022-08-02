using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _timeOfSpawn;

    private Coin _currentActiveCoin;

    private void Start()
    {
        StartCoroutine(SpawnCoinCoroutine());    
    }

    private IEnumerator SpawnCoinCoroutine()
    {
        if(_currentActiveCoin != null)
        {
            _currentActiveCoin.OnCoinTook -= SpawnCoin;
        }
        yield return new WaitForSeconds(_timeOfSpawn);
        _currentActiveCoin = Instantiate(_coin, transform.position, Quaternion.identity);
        _currentActiveCoin.OnCoinTook += SpawnCoin;
    }

    private void SpawnCoin()
    {
        StartCoroutine(SpawnCoinCoroutine());
    }
}
