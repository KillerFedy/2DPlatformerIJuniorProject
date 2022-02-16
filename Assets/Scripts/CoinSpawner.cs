using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _timeoSpawn;

    private void Start()
    {
        StartCoroutine(SpawnCoin());    
    }

    public IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(_timeoSpawn);
        Coin coin = Instantiate(_coin, transform.position, Quaternion.identity, transform);
        coin.InitSpawner(this);
    }
}
