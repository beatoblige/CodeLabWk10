using UnityEngine;
using System.Collections;
 
public class OrbitCamera : MonoBehaviour {
 
    public Transform target; // orbit object
    public Transform mycam;
 
    void Start ()
    {
 
    }
 
    void Update ()
    {
        Vector3 direction = mycam.transform.position - target.transform.position;
        direction = Vector3.ProjectOnPlane(direction, Vector3.up);
        target.transform.rotation = Quaternion.LookRotation(direction);
    }
 
 
}