using UnityEngine.Audio;
using UnityEngine;

public class DeadorAlive : MonoBehaviour {

   // private AudioSource audioSource;
 //   public AudioClip Sound;

   /* void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }*/


    public void OnTriggerEnter(Collider othe)
    {
        if (othe.tag == "Player" || othe.tag == "Player2" || othe.tag == "Player3" || othe.tag == "Player4" || othe.tag == "Player5")
        {
            GameManger.Instance.GetCoin();
            // audioSource.PlayOneShot(Sound, 0.8f);
           // So();
            Des();
        }
        else if(othe.tag == "Player1")
        {
            PlayerMotor.Crash();
            //Aud1.Play();
            Des();
        }
    }
    void Des()
    {
        Destroy(gameObject);
    }
   // void So()
   // {
   //     audioSource.PlayOneShot(Sound, 10.0f);
   // }
}
