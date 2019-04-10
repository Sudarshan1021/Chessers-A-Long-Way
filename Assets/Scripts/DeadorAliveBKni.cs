using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorAliveBKni : MonoBehaviour {

    public void OnTriggerEnter(Collider othe)
    {
        if (othe.tag == "Player3" || othe.tag == "Player4" || othe.tag == "Player5")
        {
            GameManger.Instance.GetCoin();

            Des();
        }
        else if (othe.tag == "Player" || othe.tag == "Player1" || othe.tag == "Player2")
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
