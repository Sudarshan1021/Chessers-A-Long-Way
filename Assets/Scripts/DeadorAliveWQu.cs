﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadorAliveWQu : MonoBehaviour {

    public void OnTriggerEnter(Collider othe)
    {
        if (othe.tag == "Player4")
        {
            GameManger.Instance.GetCoin();

            Des();
        }
        else if (othe.tag == "Player" || othe.tag == "Player1" || othe.tag == "Player3" || othe.tag == "Player2" || othe.tag == "Player5")
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
