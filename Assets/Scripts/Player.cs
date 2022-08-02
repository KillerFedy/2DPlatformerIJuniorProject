using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private int _jumpSpeed;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Rigidbody2D _playerRigidbody;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;

    private float _xAxisPlayerMovement;
    private void Update()
    {
        _xAxisPlayerMovement = Input.GetAxis("Horizontal");
        _animator.SetBool("isWalking", _xAxisPlayerMovement != 0);
        SetCharacterDirection(_xAxisPlayerMovement);
        _playerRigidbody.velocity = new Vector2(_xAxisPlayerMovement * _speed, _playerRigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
            _playerRigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Force);
    }

    private void ReturnToStartPoint()
    {
        transform.position = _startPoint.position;
    }

    private void SetCharacterDirection(float xAxis)
    {
        if(xAxis != 0)
        {
            _spriteRenderer.flipX = xAxis > 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ReturnToStartPoint();
        }
    }
}
