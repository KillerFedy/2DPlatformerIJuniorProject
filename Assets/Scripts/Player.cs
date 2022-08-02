using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private Transform _startPoint;

    private float _xAxisPlayerMovement;
    private Rigidbody2D _playerRigidbody;
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _xAxisPlayerMovement = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2(_xAxisPlayerMovement * _speed, _playerRigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
            _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Force);
    }

    private void ReturnToStartPoint()
    {
        transform.position = _startPoint.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ReturnToStartPoint();
        }
    }
}
