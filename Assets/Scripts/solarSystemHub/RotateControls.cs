using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControls : MonoBehaviour
{
    private Touch touch;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition;
    [SerializeField]
    private float keepRotateSpeed = 10f;

    [SerializeField]
    private float deltaThreshold = 5f;


    private void Update()
    {
        RotateThings();
    } 

    private void RotateThings()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                oldTouchPosition = touch.position;
                NewTouchPosition = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved)
            {
                oldTouchPosition = NewTouchPosition;
                NewTouchPosition = touch.position;
            }

            float delta = Mathf.Abs(oldTouchPosition.x - NewTouchPosition.x);
            if (/*touch.phase != TouchPhase.Stationary &&*/ delta >= deltaThreshold)
            {
                Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
                Debug.Log(delta);
                if (rotDirection.x < 0)
                {
                    RotateRight();
                }

                else if (rotDirection.x > 0)
                {
                    RotateLeft();
                }
            }
        }
    }

    void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(0f, 1.5f * keepRotateSpeed, 0f) * transform.rotation;
    }

    void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0f, -1.5f * keepRotateSpeed, 0f) * transform.rotation;
    }
}
