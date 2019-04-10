using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePoints : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManger.Instance.GetCoin();

            Des();


        }
    }
    void Des()
    {
        Destroy(gameObject);
    }
}
