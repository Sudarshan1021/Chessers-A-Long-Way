using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour {

    public GameObject pickupEffects;
    public AudioSource Aud;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Player1" || other.tag == "Player2" || other.tag == "Player3" || other.tag == "Player4" || other.tag == "Player5")
        {
           
            pickUp();
            PlayerMotor.Crash();
        }
    }
    void pickUp()
    {
        //Spawning a effect
        Instantiate(pickupEffects, transform.position, transform.rotation);
        //Instantiate the pickup effect to the player at the current position , current rotations

        //Apply effect to player
       
        //Destroy the powerup
        Destroy(gameObject);
    }
}
