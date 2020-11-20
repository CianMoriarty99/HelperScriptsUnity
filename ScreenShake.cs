using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This should be applied to a camera 
public class ScreenShake : MonoBehaviour
{
    //The Target the camera is following in the game
    public GameObject target;

    public float zOffset, xOffset, yOffset;

    //A holder for the shake duration
    public float shakeDuration, shakeMagnitude, dampingSpeed;

    private float duration;

    
    // Start is called before the first frame update
    void Start()
    {
        duration = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space"))
            TriggerShake(shakeDuration,shakeMagnitude,dampingSpeed); //Just a tester
        

        this.transform.position = new Vector3(target.transform.position.x -xOffset, target.transform.position.y -yOffset, -zOffset);

        if (duration > 0)
        {
            transform.localPosition = this.transform.position + Random.insideUnitSphere * shakeMagnitude;
            
            duration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            duration = 0f;
            
        }
       
    }

    public void TriggerShake(float d, float m, float s) {
        
        duration = d;
        shakeMagnitude = m;   
        dampingSpeed = s;
    }
}

