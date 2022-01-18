using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = true;

            //Linecast para detectar enemigo
            transform.position += Vector3.left * 3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = false;

            //Linecast para detectar enemigo

            transform.position += Vector3.right * 3;

        }
    }
}
