using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour {


     private AudioSource audioSource;
      public AudioClip Sound;

     void Awake()
     {
         audioSource = GetComponent<AudioSource>();
     }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "sss":
                audioSource.PlayOneShot(Sound, 0.8f);
                break;
        }
    }

    /* public AudioSource Aud;

   //  public GameObject PlayerObject;

       void Start()
     {
         Aud = GetComponent<AudioSource>();
     }

     private void OnControllerColliderHit(ControllerColliderHit hit)
     {
         switch (hit.gameObject.tag)
         {
             case "sss":
                 Aud.Play();
                 break;
         }
     }

    /*     void OnCollisionEnter(Collision col)
     {
         if(col.gameObject.tag == "sss")
         Aud.Play();
     }

    /* public void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Player")
         {
             //GameManger.Instance.GetCoin();
             //PlayerMotor.Instance.Crash();
         //    pickUp();

         }
     }

    /* void pickUp()
     {
         //Spawning a effect
         Instantiate(PlayerObject, transform.position, transform.rotation);
         //Instantiate the pickup effect to the player at the current position , current rotations

         //Apply effect to player

         //Destroy the powerup
         Destroy(gameObject);
     }*/
}
