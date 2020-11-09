using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public int levelCount = 1;
    [SerializeField] GameObject _levelText;  
    public int playerHealth = 100;
    [SerializeField] GameObject _healthText;
    public int points = 0;
    [SerializeField] GameObject _pointsText;
    [SerializeField] GameObject _gunText;
    public int armor = 0;
    [SerializeField] GameObject _armorText;

    [SerializeField] GameObject player; 
    [SerializeField] GameObject _overText;



    void Start()
    {
        _overText.GetComponent<Text>().enabled = false;
        
    }

    void Update()
    {
        
    }

    public void decreaseHealth(){
        playerHealth -= 10; 
    
        if(playerHealth == 0){
            Destroy(player);
            _overText.GetComponent<Text>().enabled = true;
        }


        _healthText.GetComponent<Text>().text = "Health : " + playerHealth;

    }

    public void setHealth(){
        playerHealth = 100;
        _healthText.GetComponent<Text>().text = "Health : " + playerHealth;
    }


    public void changeGun(string gun){
        _gunText.GetComponent<Text>().text = "Gun : " + gun;

    }

    public void increaseArmor(){ 
        armor += 25;
        _armorText.GetComponent<Text>().text = "Armor : " + armor;

    }

    public void decreaseArmor(){
        if(armor >= 10){
            armor -= 10; 
            _armorText.GetComponent<Text>().text = "Armor : " + armor;
        } else {
            armor = 0;
            _armorText.GetComponent<Text>().text = "Armor : " + armor;
        }

    }

    public void increasePoints(int n){
        points = n; 
        _pointsText.GetComponent<Text>().text = "Points : " + points;

    }

    public void increaseLevel(){
        levelCount += 1; 
        _levelText.GetComponent<Text>().text = "Level : " + levelCount;
    }

    public void buyEnd(){
        _overText.GetComponent<Text>().enabled = true;
        _overText.GetComponent<Text>().text = "You Surived The Night! Press R to Restart";
    }

}
