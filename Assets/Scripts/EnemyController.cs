using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _player;
    private bool _left;
    private bool _walking = true;
    private Rigidbody2D _rb2D;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _player = FindObjectOfType<PlayerController>().gameObject;

        if(transform.position.x < 0)
        {
            _left = true;
        }
        else
        {
            _left = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void Die(bool right)
    {

        _rb2D.gravityScale = 10f;
        if (right)
        {
            _rb2D.velocity = new Vector3(1, 2f, 0) * 15f;
            _rb2D.AddTorque(-900f);
        }
        else
        {
            _rb2D.velocity = new Vector3(-1, 2f,0) * 15f;
            _rb2D.AddTorque(900f);
        }

    }

    void Update()
    {
        if (_walking)
        {
            Vector3 direction = Vector3.left;
            if (_left)
            {
                direction = Vector3.right;
            }

            transform.Translate(direction * Time.deltaTime * 2f);
            float distance = Vector3.Distance(transform.position, _player.transform.position);

            if (distance < 1.5f)
            {
                _walking = false;
            }

        }

        else
        {

        }
       

    }
}
