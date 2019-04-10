using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {

    private const float DeadZone = 100.0f;

    public static MobileInput Instance { set; get; }

    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        //Resetting all the booleans
        tap = swipeRight = swipeLeft = swipeDown = swipeUp = false;

        //Checking for Inputs
        //Input in editor
        #region Standalone Input
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            //If touch is ended or cancelled we reset the touch
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }
        #endregion
        //Calculate Distance
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            //Checking with mobile
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position = startTouch;
            }

            //Checking with editor
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }
        //Checking if we are beyond deadzone
        if(swipeDelta.magnitude > DeadZone)
        {
            //A confirm swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x)>Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            //Once we have a confirm swipe we need to rest the swipe as we don't want two swipe at a time
            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
