using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject _zombiePrefab;
    public float spawnRate = 30f;
    void Start()
    {
        InvokeRepeating("spawnZombie", 0, 20f);
    }

    void Update()
    {
        
    }

    void spawnZombie()
    {

        Instantiate(_zombiePrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

    }

}
