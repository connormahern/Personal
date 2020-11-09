using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoundryClamp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -18.4f, 18.4f), Mathf.Clamp(transform.position.y, -11f, 11f), transform.position.z);
        
    }
}
