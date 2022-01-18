using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime;
    private float _elapsedTime;
    [SerializeField] private GameObject _enemy;
    void Start()
    {
        CreateEnemy();
    }
    private void CreateEnemy()
    {
        if (Random.value > 0.5f)
        {
            Instantiate(_enemy, Vector3.right * 10, Quaternion.identity);
        }
        else
        {
            Instantiate(_enemy, Vector3.right * -10, Quaternion.identity);
        }
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _spawnTime)
        {
            _elapsedTime = 0f;

            CreateEnemy();
        }

    }
}
