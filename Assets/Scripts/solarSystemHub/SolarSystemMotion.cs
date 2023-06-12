using UnityEngine;
using System.Collections;

namespace SolarSystemHub
{
    public class SolarSystemMotion : MonoBehaviour
    {
        RotateControls controls;

        private void Start()
        {
            controls = GetComponent<RotateControls>();
        }
        void FixedUpdate() { 
            if (controls.rotating)
                StopAllCoroutines();
            else
                StartCoroutine(Rotate());
        }

        public IEnumerator Rotate()
        {
            transform.Rotate(0, 50 * Time.deltaTime, 0);
            yield return null;
        }
    }
}