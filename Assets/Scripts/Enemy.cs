using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new List<Transform>();
    [SerializeField] private int _speed;
    private int _indexCurrentPoint;
    private void Start()
    {
        _indexCurrentPoint = Random.Range(0, _points.Count);
    }

    private void Update()
    {
        if(transform.position != _points[_indexCurrentPoint].position)
            transform.position = Vector3.MoveTowards(transform.position, _points[_indexCurrentPoint].position, _speed * Time.deltaTime);
        else
        {
            _indexCurrentPoint++;
            if (_indexCurrentPoint == _points.Count)
                _indexCurrentPoint = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.ReturnToStartPoint();
        }
    }
}
