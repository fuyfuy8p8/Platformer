using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpforce;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Rigidbody2D _rb;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _sprite.flipX = true;
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
            _animator.SetBool("isRun", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _sprite.flipX = false;
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
        }
    }
}