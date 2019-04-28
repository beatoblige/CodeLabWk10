using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    public GameObject drone;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);
        Debug.DrawRay(transform.position, transform.right * 10, Color.yellow);
        
        Debug.DrawLine(drone.transform.position, transform.position, Color.green);

        Vector3 direction = transform.position - drone.transform.position;

        Vector3 normal = Vector3.Cross(transform.right, transform.forward);

        Vector3 reflection = Vector3.Reflect(direction, normal);
        
        Debug.DrawRay(transform.position, reflection, Color.magenta);
    }
}
