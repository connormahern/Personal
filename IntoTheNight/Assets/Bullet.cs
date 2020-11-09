using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = .1f;
    Quaternion rotation;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, Time.deltaTime * _speed, 0);
    }

    void initaite(Quaternion rotation){
        this.rotation = rotation;
    }

    
    
}


