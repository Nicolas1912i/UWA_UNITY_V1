using UnityEngine;

public class PlanetClickHandler : MonoBehaviour
{
    public string mouseCollision;
    Ray ray;
    RaycastHit hit;

    public enum RayCollisions
    {
        ThirdPlanet,
        SecondPlanet,
        FirstPlanet
    }

    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {            
            if (hit.collider.name ==  RayCollisions.ThirdPlanet.ToString() || 
                hit.collider.name == RayCollisions.SecondPlanet.ToString() ||
                hit.collider.name == RayCollisions.FirstPlanet.ToString() && 
                Input.GetMouseButtonDown(0))
                mouseCollision = hit.collider.name;
        }
    }
}
