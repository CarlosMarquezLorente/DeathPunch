using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private int _hp;
    private CameraShake _cameraShake;

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            FindObjectOfType<HPUIManager>().SetHP(_hp);
            if (_hp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }


    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cameraShake = FindObjectOfType<CameraShake>();
        HP = 3;
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = true;

            //Linecast para detectar enemigo
            Vector3 startPoint = transform.position + Vector3.up;
            Vector3 targetPoint = startPoint + Vector3.left * 3;

            RaycastHit2D hit = Physics2D.Linecast(startPoint, targetPoint);
            if (hit)
            {
                GameObject enemy = hit.collider.gameObject;
                transform.position = enemy.transform.position + Vector3.right;
                enemy.GetComponent<EnemyController>().GetHit(false);
                _cameraShake.ShakeCamera(0.2f, .1f);
            }
            else
            {
                transform.position += Vector3.left * 2;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            _animator.SetTrigger("Attack");
            _spriteRenderer.flipX = false;
            //Linecast para detectar enemigo
            Vector3 startPoint = transform.position + Vector3.up;
            Vector3 targetPoint = startPoint + Vector3.right * 3;
            RaycastHit2D hit = Physics2D.Linecast(startPoint, targetPoint);
            if (hit)
            {
                GameObject enemy = hit.collider.gameObject;
                transform.position = enemy.transform.position + Vector3.left;
                enemy.GetComponent<EnemyController>().GetHit(true);
                _cameraShake.ShakeCamera(0.2f, .1f);
            }
            else
            {
                transform.position += Vector3.right * 2;
            }
        }
    }
}
