using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool _left;
    void Start()
    {
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

    void Update()
    {
        Vector3 direction = Vector3.left;
        if (_left)
        {
            direction = Vector3.right;
        }

        transform.Translate(direction * Time.deltaTime * 2f);
    }
}
