using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

    public static GameObject[] characterList;

    public static int index;
    

    private void Start()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");
        characterList = new GameObject[transform.childCount];

        //Fill the array with models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //Toggle off their renderer
        foreach (GameObject go in characterList)
            go.SetActive(false);

        //Toggle on the selected character
       if (characterList[index])
            characterList[index].SetActive(true);
        

        // characterList[0].SetActive(true);

        /*  if (index == 0)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player").SetActive(true);
          }
          if (index == 1)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player1").SetActive(true);
          }
          if (index == 2)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player2").SetActive(true);
          }
          if (index == 3)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player3").SetActive(true);
          }
          if (index == 4)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player4").SetActive(true);
          }
          if (index == 5)
          {
              characterList[index].SetActive(true);
              GameObject.FindGameObjectWithTag("Player5").SetActive(true);
          }*/
    }

    public void ToggleLeft()
    {
        //Toggle off the current level
        characterList[index].SetActive(false);

        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }
        //Toogle on the new model
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        //Toggle off the current level
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        //Toogle on the new model
        characterList[index].SetActive(true);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        
        SceneManager.LoadScene("Soldier");
    }
}
