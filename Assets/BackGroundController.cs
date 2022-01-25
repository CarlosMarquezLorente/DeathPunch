using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private Transform _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = _player.transform.position.x - transform.position.x;

        if (distance >= 30)
        {
            transform.position += Vector3.right * 60f;
        }
        
        if (distance < -30)
        {
            transform.position += Vector3.left * 60f;
        }
    }
}
