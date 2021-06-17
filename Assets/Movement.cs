using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed;
    [SerializeField] float xRange=16f;
    [SerializeField] float yRange=5f;

    [Header("Position-Controller")]
    [SerializeField] float positionpitchFactor=5f;
    [SerializeField] float controlpitchFactor=5f;
    [SerializeField] float positionyawFactor=5f;
    [SerializeField] float controlrollFactor=5f;
    float xOffset,yOffset;

    //flag means bool
    bool isPlayerAlive=true;
    

    // Update is called once per frame
    void Update()
    {
        if(isPlayerAlive)
        {
            PlayerPosition();
            PlayerRotation();
        }
        
    }

    void OnPlayerDeath()
    {
        isPlayerAlive=true;
        print("received message");
    }
    private void PlayerRotation()
    {
        //x rotation means pitch,y rotation means yaw,z rotation means roll
        //float xRotation=transform.localPosition.x*rotationFactor+xOffset;
        float yRotation=transform.localPosition.y*positionpitchFactor;//10
        //float zRotation=transform.localPosition.z*rotationFactor;
        float pitchControlValue=yOffset*controlpitchFactor;//-20
        float pitch=yRotation+pitchControlValue;

        float yaw=transform.localPosition.x*positionyawFactor;

        float roll=xOffset*controlrollFactor;
        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }
    private void PlayerPosition()
    {
        float horizontalMove=CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalMove=CrossPlatformInputManager.GetAxis("Vertical");

        xOffset=horizontalMove*speed*Time.deltaTime;
        yOffset=verticalMove*speed*Time.deltaTime;

        float xRawPos=transform.localPosition.x+xOffset;
        float yRawPos=transform.localPosition.y+yOffset;

        float clampedXpos=Mathf.Clamp(xRawPos,-xRange,xRange);
        float clampedYpos=Mathf.Clamp(yRawPos,-yRange,yRange);

        transform.localPosition=new Vector3(clampedXpos,clampedYpos,transform.localPosition.z);
    }
    
}    
