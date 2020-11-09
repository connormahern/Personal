using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class zombie : MonoBehaviour
{
    [SerializeField] RunTimeData rt;
    [SerializeField] GameObject player;
    [SerializeField] GameObject currentGun;
    [SerializeField] GameObject gs;
    private Rigidbody2D rb;
    private Vector2 move;
    private float moveSpeed = .35f;

    private int health = 100;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        currentGun = GameObject.Find("CurrentGun");

        gs = GameObject.Find("GameState"); 

        moveSpeed = moveSpeed + (float)(gs.gameObject.GetComponent<GameState>().levelCount * .15);
        Debug.Log(gs.gameObject.GetComponent<GameState>().levelCount);
        Debug.Log(moveSpeed);
        health = health + (int)(gs.gameObject.GetComponent<GameState>().levelCount * 25);
    }

    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        move = direction; 

        if(health <= 0){
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        moveZombie(move);
    }

    void moveZombie(Vector2 direction)
    {
        if(rt.playerInZone == false){
            rb.MovePosition((Vector2) transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damage Taken");

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "IntoTheNightBullet(Clone)"){
            TakeDamage(currentGun.GetComponent<GunOptions>().damage);
            Destroy(col.gameObject);
            player.gameObject.GetComponent<player>().points += 10; 
            Debug.Log("Bullet Impact");

            
        }
    }

    
}
