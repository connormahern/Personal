using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] RunTimeData rt;
    [SerializeField] GameState gs;


    void Awake()
    {
        rt.playerInZone = false;
        rt.canFire = false;
        rt.gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
