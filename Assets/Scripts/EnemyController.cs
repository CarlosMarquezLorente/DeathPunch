using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _player;
    private bool _left,_dead;
    private bool _walking = true;
    private Rigidbody2D _rigidbody;
    private PlayerController _playerController;

    private int _hp;
    [SerializeField]private List<bool> _hpSides;
    [SerializeField]private List<SpriteRenderer> _hpBars;

    
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _player = _playerController.gameObject;

        _rigidbody = GetComponent<Rigidbody2D>();
        
        if((_player.transform.position - transform.position).x > 0)
        {
            _left = true;
        }
        else
        {
            _left = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        _hp = Random.Range(1, 3);
        _hpSides = new List<bool>();
        //Añadimos el primer elemnto "manualmente
        _hpSides.Add(!_left);

        //Para reactivar solo las que usemos luego en el bucle for
        //desactivamos todo slos sprites renderer de las barras de vida de los enemigos
        foreach (SpriteRenderer s in _hpBars)
        {
            s.enabled = false;
        }

        if (_hpSides[0])
        {
            _hpBars[0].color = Color.blue;
        }
        else
        {
            _hpBars[0].color = Color.red;

        }


        for (int i = 1; i < _hp; i++)
        {
            _hpBars[i].enabled = true;

            if (Random.value<0.5f)
            {
                _hpSides.Add(false);
                _hpBars[i].color = Color.blue;
            }
            else
            {
                _hpSides.Add(true);
                _hpBars[i].color = Color.red;
            }
        }
    }
    public void GetHit(bool right)
    {

        _walking = false;
        _hp--;
        _hpSides.RemoveAt(0);

        if (_hp<=0)
        {
            Die(right);
        }
        else
        {
            if (_hpSides[0])
            {
                transform.position = _player.transform.position + 1.5f * Vector3.right;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                transform.position = _player.transform.position - 1.5f * Vector3.right;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            _hpBars[0].enabled = false;
            for (int i = 0; i < _hpBars.Count; i++)
            {
                _hpBars[i].transform.localPosition -= Vector3.up * 0.4f;
            }
        }
    }

    public void Die(bool right)
    {
        _dead = true;

        GameManager.points++;//sumamos puntos

        GetComponent<BoxCollider2D>().enabled = false;
        _rigidbody.gravityScale = 8f;
        if (right)
        {
            _rigidbody.velocity = new Vector3(1, 2f, 0).normalized * 30;
            _rigidbody.AddTorque(-900);
            
        }
        else
        {
            _rigidbody.velocity = new Vector3(-1, 2f, 0).normalized * 30;
            _rigidbody.AddTorque(900);
        }

        foreach (SpriteRenderer a in _hpBars)
        {
            a.enabled = false;
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
            if(distance < 1.5f)
            {
                _walking = false;
                StartCoroutine(HitPlayer(0.5f));
            }
        }                   
        if (transform.position.y < -10) 
        {
            Destroy(gameObject);
        }
       

    }
    IEnumerator HitPlayer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (!_dead)
        {
            _playerController.HP--;
        }

        StartCoroutine(HitPlayer(1f));
    }
}
