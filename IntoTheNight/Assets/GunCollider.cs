using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollider : MonoBehaviour
{

    [SerializeField] RunTimeData rt;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player" && rt.gameOver == false){
            rt.playerInZone = true;
            //Debug.Log("Entered");
        }
        
        
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            rt.playerInZone = false;
            //Debug.Log("Exit");
        }
        
    }
}
