using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class player : MonoBehaviour
{
    [SerializeField] RunTimeData rt;

    [SerializeField] GameState gs;

    public GameObject currentGun;

    [SerializeField] GameObject _promptText;
    
    public float movementSpeed = 3f;
    public float rotationSpeed = 2f;

    private int health = 100;

    public int points = 0;

    public int armor = 0; 

    public Rigidbody2D RB;

    Vector2 movement;

    int colliderEntered = 0;


    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        userInput();
        gs.increasePoints(points);

        //Pistol Case
        if(Input.GetKey(KeyCode.G) && points >= 100 && colliderEntered == 1){
                currentGun.GetComponent<GunOptions>().damage = 50;
                currentGun.GetComponent<GunOptions>().startTimeAttack = .25f;
                points -= 100;
                gs.changeGun("Pistol");
                rt.canFire = true;
                colliderEntered = 0;
        }

        //Rifle Case
        if(Input.GetKey(KeyCode.G) && points >= 300 && colliderEntered == 2){
            if(gs.levelCount >= 3){
                currentGun.GetComponent<GunOptions>().damage = 150;
                currentGun.GetComponent<GunOptions>().startTimeAttack = .50f;
                points -= 300;
                gs.changeGun("Rifle");
                rt.canFire = true;
                colliderEntered = 0;
            } 
        }

        //Machine Case
        if(Input.GetKey(KeyCode.G) && points >= 500 && colliderEntered == 3){
            if(gs.levelCount >= 5){
                currentGun.GetComponent<GunOptions>().damage = 75;
                currentGun.GetComponent<GunOptions>().startTimeAttack = .15f;
                points -= 500;
                gs.changeGun("Machine Gun");
                rt.canFire = true;
                colliderEntered = 0;
            } 
        }

        //Armor Increment
        if(Input.GetKey(KeyCode.G) && points >= 200 && colliderEntered == 4){
                if((gs.armor + 25) <= 100){
                    points -= 200;
                    gs.increaseArmor();
                } else {
                    _promptText.GetComponent<Text>().text = "Armor full or within 25 of Full";
                }
                colliderEntered = 0;
        }

        //Level Incrament
        if(Input.GetKey(KeyCode.G) && points >= 500 && colliderEntered == 5){
                points -= 500;
                gs.increaseLevel();
                colliderEntered = 0;
                gs.setHealth();
        }

        //Buyable Ending...
        if(Input.GetKey(KeyCode.G) && points >= 0 && colliderEntered == 6){
            rt.gameOver = true;
            rt.playerInZone = true;
            gs.buyEnd();
            colliderEntered = 0;
        }

        


    }

    void FixedUpdate()
    {
        if(rt.gameOver == false){
            MovePlayer();
            RotatePlayer();
        }
        
    }

    private void userInput()
    {
        //For Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        RB.velocity = transform.right * Mathf.Clamp01(movement.y) * movementSpeed;
    }

    private void RotatePlayer()
    {
        float rotation = (- movement.x) * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.name == "zombie(Clone)"){
            if(gs.armor > 0){
                gs.decreaseArmor();
            } else {
                gs.decreaseHealth();
            }
        }

        if(collider.gameObject.name == "PistolCollider"){
            _promptText.GetComponent<Text>().text = "Pistol : 100 Points (Press G to Purchase)";
            colliderEntered = 1;

        }

        if(collider.gameObject.name == "RifleCollider"){
            if(gs.levelCount >= 3){
                _promptText.GetComponent<Text>().text = "Rifle : 300 Points (Press G to Purchase)";
                colliderEntered = 2;
            } else {
                _promptText.GetComponent<Text>().text = "Not Avaiable till level 3";
            }

        }

        if(collider.gameObject.name == "MachineCollider"){
            if(gs.levelCount >= 5){
                _promptText.GetComponent<Text>().text = "Machine Gun : 500 Points (Press G to Purchase)";
                colliderEntered = 3;
            } else {
                _promptText.GetComponent<Text>().text = "Not Avaiable till level 5";
            }
        }

        if(collider.gameObject.name == "ArmorCollider"){
            _promptText.GetComponent<Text>().text = "Upgrade Armor by 25 : 200 points (Press G to Purchase)";
            colliderEntered = 4;
        }

        if(collider.gameObject.name == "LevelUpgradeCollider"){
            _promptText.GetComponent<Text>().text = "Advance Level : 500 points (Press G to Purchase)";
            colliderEntered = 5;
        }

        if(collider.gameObject.name == "EndGameCollider"){
            _promptText.GetComponent<Text>().text = "Buyable Ending : 10000 points (Press G to Purchase)";
            colliderEntered = 6;
        }

         
    }

    void OnTriggerExit2D(Collider2D collider){

        if(collider.gameObject.name == "PistolCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }

        if(collider.gameObject.name == "RifleCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }

        if(collider.gameObject.name == "MachineCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }

        if(collider.gameObject.name == "ArmorUpgradeCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }

        if(collider.gameObject.name == "LevelUpgradeCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }

        if(collider.gameObject.name == "EndGameCollider"){
            _promptText.GetComponent<Text>().text = "";
            colliderEntered = 0;
        }


    }

}
