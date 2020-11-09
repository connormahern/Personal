using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunStatus : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject currentGun;

    [SerializeField] RunTimeData rt;

    private float timeAttack;
    private float startTimeAttack; 
    public float bulletForce = .001f;


    void Start()
    {
        currentGun = GameObject.Find("CurrentGun");
        
    }

    // Update is called once per frame
    void Update()
    {
        startTimeAttack = currentGun.GetComponent<GunOptions>().startTimeAttack;
    

        if(rt.canFire == true ){
            if (timeAttack <= 0){
                if(Input.GetKey(KeyCode.F)){ 
                    fireWeapon();
                }
                timeAttack = startTimeAttack;
            } else {
                timeAttack -= Time.deltaTime;
            }
        }
        
    }

    void fireWeapon(){
        GameObject bullet = Instantiate(_bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);   
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        
    }
}
