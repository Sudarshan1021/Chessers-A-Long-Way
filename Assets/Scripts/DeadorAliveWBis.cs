using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorAliveWBis : MonoBehaviour {

    void OnTriggerEnter(Collider othe)
    {
        if (othe.tag == "Player2" || othe.tag == "Player4" || othe.tag == "Player5")
        {
            GameManger.Instance.GetCoin();

            Des();
        }
        else if (othe.tag == "Player" || othe.tag == "Player1" || othe.tag == "Player3")
        {
            PlayerMotor.Crash();

            Des();
        }
    }
    void Des()
    {
        Destroy(gameObject);
    }
}
