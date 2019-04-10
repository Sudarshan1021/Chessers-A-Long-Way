using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorAliveSound : MonoBehaviour {

    public AudioSource Aud;
    public AudioSource Aud1;

    public void OnTriggerEnter(Collider othe)
    {
        if (othe.tag == "Player")
        {
            Aud.Play();

        }
        else if (othe.tag == "Player1" || othe.tag == "Player2" || othe.tag == "Player3" || othe.tag == "Player4" || othe.tag == "Player5")
        {
            Aud1.Play();
        }
    }
}
