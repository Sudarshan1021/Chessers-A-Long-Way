using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {

    private const int REDGOLD_SCORE = 5;
    private int lastScore;

    public bool stop = false;

   // public GameObject Characters;

		public static GameManger Instance { set; get; } // To make the game manager available in other scripts

    private bool isGameStarted = false;
 //   private PlayerMotor motor;
   // private PlayerMotor motor1;

    //UI
    public Text scoreText, RedGoldText, modifierText;
    private float score, RedGoldScore, modifierScore;

    //Death menu

    public Animator deathMenuAnim;
    public Text deadscoreText, deadRedGoldText;

    private float animationDuration = 5.5f;

    private void Awake()
    {
        Instance = this; // We need to instantiate it at the starting
        modifierScore = 1.0f;
        // motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
        // motor = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMotor>();
       // m1();
       // m2();

        modifierText.text = "x" + modifierScore.ToString("F1");
        RedGoldText.text = RedGoldScore.ToString("0");
        scoreText.text = scoreText.text = score.ToString("0");
    }
  /*  void m1()
    {
        motor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMotor>();
    }
    void m2()
    {
        motor1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerMotor>();
    }*/

    

    public void Update()
    {

        if (Time.time < animationDuration)
        {
            return;
            
        }
        if (stop)
        {
            return;
        }
        else
        {
            isGameStarted = true;
            PlayerMotor.isRunning = true;

        }
       /* if (MobileInput.Instance.Tap && !isGameStarted)
       {
            isGameStarted = true;
            PlayerMotor.isRunning = true;
        }*/

        if (isGameStarted)
        {
            if (stop)
                return;
            //Start the score text
            lastScore = (int)score;
            score += (Time.deltaTime * modifierScore);
            if(lastScore != (int)score)
            {
                lastScore = (int)score;
            }
            scoreText.text = score.ToString("0"); // Not calling UpdateScore function as it will be heavy for CPU
        }
    }

    public void GetCoin()
    {
        RedGoldScore++;
        RedGoldText.text = RedGoldScore.ToString("0");
        score += REDGOLD_SCORE;
        scoreText.text = scoreText.text = score.ToString("0");
    }

    

    public void UpdateModifier(float modifierAmount)
    {
        if (stop)
            return;
        modifierScore = 1.0f + modifierAmount;
        modifierText.text = "x" + modifierScore.ToString("F1");
    }

    public void OnPlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Soldier");
    }

    public void OnDeath()
    {
        stop = true;
        deadscoreText.text = score.ToString("0");
        deadRedGoldText.text = RedGoldScore.ToString("0");
        deathMenuAnim.SetTrigger("Dead");

    }
    public void Chang()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelection");
    }
    public void Men()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
