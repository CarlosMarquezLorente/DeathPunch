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
        if (Input.GetMouseButtonDown(0)) //ataque a la izquierda
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = true;
            //Linecast para detectar enemigo

            Vector3 startPoint = transform.position + Vector3.up;
            Vector3 targectPoint = startPoint + Vector3.left * 3;
            RaycastHit2D hit = Physics2D.Linecast(startPoint, targectPoint);

            if (hit)
            {
                GameObject enemy = hit.collider.gameObject;
                transform.position = enemy.transform.position + Vector3.right;
                
                enemy.GetComponent<EnemyController>().Die(false);
                print("Enemigo");
            }
            else
            {
                transform.position += Vector3.left * 3;
                print("nada");
            }

        }

        if (Input.GetMouseButtonDown(1))//ataque a la derecha
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = false;
            //Linecast para detectar enemigo

            Vector3 startPoint = transform.position + Vector3.up;
            Vector3 targectPoint = startPoint + Vector3.right * 2.5f;
            RaycastHit2D hit = Physics2D.Linecast(startPoint, targectPoint);

            if (hit)
            {
                GameObject enemy = hit.collider.gameObject;
                transform.position = enemy.transform.position + Vector3.left;
                
                enemy.GetComponent<EnemyController>().Die(true);

                print("Enemigo");
            }
            else
            {
                transform.position += Vector3.right* 2.5f;

                print("nada");
            }


        }
    }
}
