using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour {

    private Transform lookAt;//Every scene in the object will have a transform which is used to store and manipulate the position, rotation, scale of the object
    private Vector3 moveVector; // Representation of 3d vector and points
    private float transition = 0.0f;
    private float animationDuration = 5.5f;
    private Vector3 animationOffset = new Vector3(-150, 0, 0);
    //public Transform lookAt1;
    //public Transform lookAt2;
    //public Transform lookAt3;
    //public Transform lookAt4;
   // public Transform lookAt5;

    private Vector3 startOffset;
   // private Vector3 startOffset1;
   // private Vector3 startOffset2;
   // private Vector3 startOffset3;
   // private Vector3 startOffset4;
   // private Vector3 startOffset5;
  
    /*void m11()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;

    }
    void m12()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player1").transform;
        startOffset1 = transform.position - lookAt.position;

    }
    void m13()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player2").transform;
        startOffset2 = transform.position - lookAt.position;

    }
    void m14()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player3").transform;
        startOffset3 = transform.position - lookAt.position;
    }
    void m15()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player4").transform;
        startOffset4 = transform.position - lookAt.position;
    }
    void m16()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player5").transform;
        startOffset5 = transform.position - lookAt.position;
    }*/

    void Start()
    {
      //  moveVector.z = -20.2f;
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player").transform;// We are getting the current position of the player
            startOffset = transform.position - lookAt.position;
        }
        else if  (GameObject.FindGameObjectWithTag("Player1"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player1").transform;
            startOffset = transform.position - lookAt.position;

        }
        else if (GameObject.FindGameObjectWithTag("Player2"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player2").transform;
            startOffset = transform.position - lookAt.position;
        }
        else if (GameObject.FindGameObjectWithTag("Player3"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player3").transform;
            startOffset = transform.position - lookAt.position;
        }
        else if (GameObject.FindGameObjectWithTag("Player4"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player4").transform;
            startOffset = transform.position - lookAt.position;
        }
        else if (GameObject.FindGameObjectWithTag("Player5"))
        {
            lookAt = GameObject.FindGameObjectWithTag("Player5").transform;
            startOffset = transform.position - lookAt.position;
        }
       /* switch (gameObject.tag) {

            case "Player":  m11();break;
            case "Player1":
                m12(); break;
            case "Player2":
                m13(); break;
            case "Player3":
                m14(); break;
            case "Player4":
                m15(); break;
            case "Player5": m16(); break;
        }*/
       
        
    }

/*  void Update()
  {
      moveVector = lookAt.position+startOffset;

      //X
      moveVector.x = 0;

      //Y

      moveVector.y = Mathf.Clamp(moveVector.y,12.5f,20);

      transform.position = moveVector;


  }*/
//  public Vector3 offset = new Vector3(0, 5.0f,-10.0f);

private void Update()
{
        if (GameObject.FindGameObjectWithTag("Player") || GameObject.FindGameObjectWithTag("Player1") || GameObject.FindGameObjectWithTag("Player2") || GameObject.FindGameObjectWithTag("Player3") || GameObject.FindGameObjectWithTag("Player4") || GameObject.FindGameObjectWithTag("Player5"))
        {
            moveVector = lookAt.position + startOffset;

            //X
            moveVector.x = 0;

            //Y

            moveVector.y = Mathf.Clamp(moveVector.y, 25,25);

            //Z

            if (transition > 1.0f)
            {

                 transform.rotation = Quaternion.identity; // This represents no rotation. The object is perfectly aligned with the parent axes
               // transform.position = Vector3.Lerp(moveVector, moveVector, transition);
                transform.position = moveVector;
            }
            else
            {
                //Animation at the start of the game
                transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
                transition += Time.deltaTime * 1 / animationDuration; //After one second transistion = 1(1/animation duration = 0.5 , time.deltatime = one second)
                transform.LookAt(lookAt.position + Vector3.up);
            }
       }
    }
      /*  switch (gameObject.tag)
        {

            case "Player": m1(); break;
            case "Player1":
                m2(); break;
            case "Player2":
                m3(); break;
            case "Player3":
                m4(); break;
            case "Player4":
                m5(); break;
            case "Player5": m6(); break;
        }
        //  Vector3 desiredPosition = lookAt.position + offset;
        //   desiredPosition.x = 0;
        //   transform.position = Vector3.Lerp(transform.position, desiredPosition,Time.deltaTime);
    }

    void m1()
    {
        moveVector = lookAt.position + startOffset;

        //X
        moveVector.x = 0;

        //Y

        moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

        transform.position = moveVector;
    }
    void m2()
    {
        moveVector = lookAt.position + startOffset1;

        //X
        moveVector.x = 0;

        //Y

        moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

        transform.position = moveVector;
    }
    void m3()
    {
        moveVector = lookAt.position + startOffset2;

        //X
        moveVector.x = 0;

        //Y

        moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

        transform.position = moveVector;
    }
    void m4()
    {
        moveVector = lookAt.position + startOffset3;

        //X
        moveVector.x = 0;

        //Y

        moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

        transform.position = moveVector;
    }
        void m5()
    {
            moveVector = lookAt.position + startOffset4;

            //X
            moveVector.x = 0;

            //Y

            moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

            transform.position = moveVector;
        }
    void m6()
    {
            moveVector = lookAt.position + startOffset5;

            //X
            moveVector.x = 0;

            //Y

            moveVector.y = Mathf.Clamp(moveVector.y, 12.5f, 20);

            transform.position = moveVector;
        }*/
        
}
