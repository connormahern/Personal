using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offest = new Vector3(0,0,-1);
    public Vector2 min;
    public Vector2 max;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(player){
            

            transform.position = new Vector3(player.transform.position.x + offest.x, player.transform.position.y + offest.y, player.transform.position.z + offest.z);

        }
        
    }
}
