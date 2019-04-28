using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] GameObject deathFX;

    [SerializeField] Transform parent;

    
    [SerializeField] private int scorePerHit = 100;
    [SerializeField] private int hits = 7;
   
    Scoreboard scoreboard;
    // Start is called before the first frame update
    void Start()
    {
       
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>(); //look at runtime 
        
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    

    private void OnParticleCollision(GameObject other)
    {
        hits = hits - 1; 
        scoreboard.ScoreHit(scorePerHit);
        if ( hits <= 1)
        {
            KillEnemy();
        }
       
    }

    private void KillEnemy()
    {
        GameObject fx= Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
