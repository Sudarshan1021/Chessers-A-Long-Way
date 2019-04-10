using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {
   // public GameObject ship;
	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Player");
            this.gameObject.SetActive(true);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
