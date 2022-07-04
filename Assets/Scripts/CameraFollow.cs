using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speedAcc = .3f;

    public void Play()
    {
        target.position = new Vector3(0,0,0);
    }
   
    void LateUpdate() 
    {
        if(target.position.y > transform.position.y){
            Vector3 newPosition = new Vector3(transform.position.x,target.position.y,transform.position.x);
            transform.position = newPosition;
        }
        
    }
}
