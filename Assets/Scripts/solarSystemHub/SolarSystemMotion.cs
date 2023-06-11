using UnityEngine;

public class SolarSystemMotion : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
