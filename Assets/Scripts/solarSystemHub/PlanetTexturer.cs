using UnityEngine;

namespace SolarSystemHub
{
    public class PlanetTexturer : MonoBehaviour
    {
        [SerializeField] private Texture2D[] frames;
        [SerializeField] private float fps = 1.0f;

        private Material mat;

        void Start()
        {
            mat = GetComponent<Renderer>().material;
        }

        void Update()
        {
            int index = (int)(Time.time * fps);
            index = index % frames.Length;
            mat.mainTexture = frames[index];
        }
    }
}