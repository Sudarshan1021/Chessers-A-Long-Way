using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection1 : MonoBehaviour {
    
    
    // Use this for initialization
    void Start () {

    /*    foreach (GameObject go in CharacterSelection.characterList)
            go.SetActive(false);

        if (CharacterSelection.characterList[0])
            CharacterSelection.characterList[0].SetActive(true);
        if (CharacterSelection.characterList[1])
            CharacterSelection.characterList[1].SetActive(true);
        if (CharacterSelection.characterList[2])
            CharacterSelection.characterList[2].SetActive(true);
        if (CharacterSelection.characterList[3])
            CharacterSelection.characterList[3].SetActive(true);
        if (CharacterSelection.characterList[4])
            CharacterSelection.characterList[4].SetActive(true);
        if (CharacterSelection.characterList[5])
            CharacterSelection.characterList[5].SetActive(true);*/
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (GameObject go in CharacterSelection.characterList)
            go.SetActive(false);

        if (CharacterSelection.characterList[0])
            CharacterSelection.characterList[0].SetActive(true);
        if (CharacterSelection.characterList[1])
            CharacterSelection.characterList[1].SetActive(true);
        if (CharacterSelection.characterList[2])
            CharacterSelection.characterList[2].SetActive(true);
        if (CharacterSelection.characterList[3])
            CharacterSelection.characterList[3].SetActive(true);
        if (CharacterSelection.characterList[4])
            CharacterSelection.characterList[4].SetActive(true);
        if (CharacterSelection.characterList[5])
            CharacterSelection.characterList[5].SetActive(true);

    }
}
