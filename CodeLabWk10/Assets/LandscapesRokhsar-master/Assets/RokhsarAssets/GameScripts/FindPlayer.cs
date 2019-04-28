using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    public float speed = 1;
    
    GameObject player;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
        rb = GetComponent<Rigidbody>();
        
        Debug.Log("Found the gameObject: " + player.name);
    }

    // Update is called once per frame
    void Update()
    {   
       
        Vector3 direction = player.transform.position - transform.position;

       
        direction.Normalize();

     

       
        
        Quaternion newQuatDir = Quaternion.LookRotation(direction);

//        

        float dotProduct = Vector3.Dot(direction, transform.forward);
        
        print("Dot: " + dotProduct);
        
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
        Debug.DrawRay(transform.position, direction * 10, Color.red);

        if (dotProduct > 0.5f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, newQuatDir, Time.deltaTime);

            rb.velocity = transform.forward * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
