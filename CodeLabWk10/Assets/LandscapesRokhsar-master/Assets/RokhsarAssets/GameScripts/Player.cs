using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour //DEALS PRIMARY W/ INTREPID1 MOVEMENT
{

    [Header("General")]
    [Tooltip("In ms^-1")][SerializeField] float Controlspeed = 25f;
    [Tooltip("In m")] [SerializeField] float xRange = 13f;
    [Tooltip("In m")] [SerializeField] float yRange = 15f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position Focused")]
    [SerializeField] float positionPitchFactor = -3f;
   [SerializeField] float positionYawFactor = +2f;
   
     [Header("Screen-control Focused")]
[SerializeField] float controlRollFactor = -10f;
    [SerializeField] float controlPitchFactor = -10f;

    float xThrow, yThrow;
    bool controlEnabled = true;

    void Update()
    {
        if (controlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();

        }
    }
      


    void OnPlayerDeath() //called by string reference 
    {
        controlEnabled = false;
    }


    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y + positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor ;;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }


    private void ProcessTranslation()
    {
       xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //refers to everything by an axis
       yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * Controlspeed * Time.deltaTime;
        float yOffset = yThrow * Controlspeed * Time.deltaTime;


        float rawXPos = transform.localPosition.x + xOffset;  
        float clampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYpos = Mathf.Clamp(rawYPos, -yRange, yRange);
       


        transform.localPosition
                 = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z); 
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
        
            
        
    }
}


  