using UnityEngine;
using System.Collections;
 
public class OrbitShip : MonoBehaviour {
 
    public Transform target;
    public float orbitDistance = 5.0f;
    public float orbitDegreesPS = 180.0f;// half an orbit per second. 
    public Vector3 relativeDistance = Vector3.zero;
     
    // Use this for initialization
    void Start () {
     
        if(target != null) 
        {
            relativeDistance = transform.position - target.position;
        }
    }
     
    void Orbit()
    {
        if(target != null)
        {
            // Drone should be above ship's last position and rotating at a constant speed w/ particle bullet in every direction 
            transform.position = target.position + relativeDistance;
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPS * Time.deltaTime);
            relativeDistance = transform.position - target.position;
        }
    }
     
    void LateUpdate () {
         
        Orbit();
     
    }
}