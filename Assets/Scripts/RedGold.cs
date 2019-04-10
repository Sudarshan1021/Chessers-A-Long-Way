using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGold : MonoBehaviour
{

    public GameObject pickupEffect;
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"|| other.tag == "Player1" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4" || other.tag == "Player5")
        {
            GameManger.Instance.GetCoin();
            pickUp();
            
        }
    }
  
    void pickUp()
    {
        //Spawning a effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Instantiate the pickup effect to the player at the current position , current rotations

        //Apply effect to player

        //Destroy the powerup
        Destroy(gameObject);
        
    }
}