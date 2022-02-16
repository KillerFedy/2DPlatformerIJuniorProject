using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner _spawner;

    public void InitSpawner(CoinSpawner spawner)
    {
        _spawner = spawner;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            _spawner.StartCoroutine(_spawner.SpawnCoin());
            Destroy(gameObject);
        }
    }
}
