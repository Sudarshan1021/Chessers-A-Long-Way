using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor  : MonoBehaviour{ 

    private const float Lane_distance = 15.0f;
    private const float Turn_speed = 5.0f;

 //   public static GameObject Object;


    public static bool isRunning = false;

    private CharacterController controller;
    private float jumpForce = 52.0f;
    private float gravity = 75.0f;
    private float verticalVelocity;
 
    private float xvector = 50.0f;
    private int desiredlane = 1; // 0 = Left , 1 = Middle , 2 = Right

    //Speed Modifier
    private float orginalspeed = 25.0f;
    private float speed;
    private float speedIncreaseLastTick;
    private float speedIncreaseTime = 2.5f;
    private float speedIncreaseAmount = 0.1f;

    public void Start()
    {
        speed = orginalspeed;
        controller = GetComponent<CharacterController>();
        
    }

    public void Update()
    {
        if (!isRunning)
            return;

        if(Time.time - speedIncreaseLastTick>speedIncreaseTime)
        {
            speedIncreaseLastTick = Time.time;
            speed += speedIncreaseAmount;
            GameManger.Instance.UpdateModifier(speed - orginalspeed);

        }
        //Gather the inputs in which lane we should be
        //Before the code Mobile Input foe checking in editor
        /* if (Input.GetKeyDown(KeyCode.LeftArrow))
             MoveLane(false);
         if (Input.GetKeyDown(KeyCode.RightArrow))
             MoveLane(true);*/

        //After the script Mobile Input
        if (MobileInput.Instance.SwipeLeft)
            MoveLane(false);
        if (MobileInput.Instance.SwipeRight)
            MoveLane(true);

        //Calculating where we should be in the future
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredlane == 0)
            targetPosition += Vector3.left * Lane_distance;
        else if (desiredlane == 2)
            targetPosition += Vector3.right * Lane_distance;

        //Calculating move delta
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * xvector;

        //Calculating Y for gravity

       if (IsGrounded())
        {
            verticalVelocity = -0.1f;

            //if(Input.GetKeyDown(KeyCode.Space))   - Before Mobile input
            if(MobileInput.Instance.SwipeUp)
            {
                //Jump
                verticalVelocity = jumpForce;
            }
        /*    else if (MobileInput.Instance.SwipeDown)
            {
                //Sliding
                StartCoroutine(Example());
                Invoke("StopSliding", 5.0f);
            }*/
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            //Fast falling
            //if (Input.GetKeyDown(KeyCode.Space))
            if(MobileInput.Instance.SwipeDown)
            {
                verticalVelocity -= jumpForce;
            }
        }
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        //Moving the Player
        controller.Move(moveVector * Time.deltaTime);


        //Making the player to move fast to the desired lane
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            dir.x = 360;
            transform.forward = Vector3.Lerp(dir, dir, Turn_speed);
        }
    }

    private void MoveLane(bool goingRight)
    {
        desiredlane += (goingRight) ? 1 : -1;
        desiredlane = Mathf.Clamp(desiredlane, 0, 2);
    }

    private bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3(controller.bounds.center.x, (controller.bounds.center.y - controller.bounds.extents.y) +0.2f, controller.bounds.center.z), Vector3.down);
        return Physics.Raycast(groundRay, 0.2f+ 0.1f);
        
    }

    public void StartRunning()
    {
        isRunning = true;
    }

    /*IEnumerator Example()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, -70.0f, 0);
        yield return new WaitForSeconds(5);
    }
    public void StartSliding()
    {
         transform.rotation = new Quaternion(0.0f, 0.0f, -70.0f,0);
      //   transform.Rotate(-70, 0, 0, Space.World);
    }
    private void StopSliding()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0);
     //   transform.Rotate(0, 0, 0, Space.World);
    }*/

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Obstacle":
                Crash();
                break;

            case "ObPawnB":
                Crash();
                break;
            case "ObPawnW":
                Crash();
                break;
            case "ObKnightW":
                Crash();
                break;
            case "ObKnightB":
                Crash();
                break;
            case "ObBishopB":
                Crash();
                break;
            case "ObBishopW":
                Crash();
                break;
            case "ObRook":
                Crash();
                break;
            case "ObQueenB":
                Crash();
                break;
            case "ObQueenW":
                Crash();
                break;
            case "ObKing":
                Crash();
                break;

        }
    }
    public static void Crash()
        {
        // Object.SetActive(true);
        //  m1();
        GameManger.Instance.OnDeath();
        isRunning = false;
        
    }
   //static void m1()
    //{
   //     Object.SetActive(true);

   // }
}
