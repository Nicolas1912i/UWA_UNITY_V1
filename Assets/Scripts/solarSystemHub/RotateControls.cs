using UnityEngine;

namespace SolarSystemHub
{
    public class RotateControls : MonoBehaviour
    {
        Touch touch;
        Vector2 oldTouchPosition, NewTouchPosition;
        [SerializeField] float keepRotateSpeed = 1f;
        [SerializeField]float deltaThreshold = 1f;
        [HideInInspector] public bool rotating = false;

        void Update() { RotateThings(); }

        void RotateLeft() { transform.rotation = Quaternion.Euler(0f, 1.5f * keepRotateSpeed, 0f) * transform.rotation; }
        void RotateRight() { transform.rotation = Quaternion.Euler(0f, -1.5f * keepRotateSpeed, 0f) * transform.rotation; }

        void RotateThings()
        {
            if (Input.touchCount > 0)
            {
                rotating = true;
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    oldTouchPosition = touch.position;
                    NewTouchPosition = touch.position;
                } else if (touch.phase == TouchPhase.Moved) {
                    oldTouchPosition = NewTouchPosition;
                    NewTouchPosition = touch.position;
                }

                float delta = Mathf.Abs(oldTouchPosition.x - NewTouchPosition.x);
                if (delta >= deltaThreshold)
                {
                    Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
                    if (rotDirection.x < 0)
                        RotateRight();
                    else if (rotDirection.x > 0)
                        RotateLeft();
                }
            } else { rotating = false; }
        }
    }
}