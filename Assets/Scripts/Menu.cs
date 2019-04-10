using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {


    public void Star()
    {
        SceneManager.LoadScene("CharacterSelection");
        //Application.LoadLevel("CharacterSelection");
    }
    public void Qui()
    {
        //SceneManager.LoadScene("Soldier");
        Application.Quit();
    }
    public void Nov()
    {
        SceneManager.LoadScene("Novice");
        // Application.LoadLevel("Novice");
    }
    public void Con()
    {
        SceneManager.LoadScene("Controls");
        //  Application.LoadLevel("Controls");
    }
   
}
