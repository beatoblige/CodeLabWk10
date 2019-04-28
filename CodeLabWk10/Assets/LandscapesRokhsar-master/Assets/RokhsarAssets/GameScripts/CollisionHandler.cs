using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //only script that loads scenes

public class CollisionHandler : MonoBehaviour
{


    [Tooltip("In Seconds")] 
    [SerializeField]  float levelLoadDelay = 1f;

   
    [Tooltip("FX Prefab on player")] 
    [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
        
    }

    private void StartDeathSequence()
    {
      
        print("Player dying");
        SendMessage("OnPlayerDeath");
        
    }

    private void ReloadScene() //string reference
    {
        SceneManager.LoadScene(1);
        
    }
}
