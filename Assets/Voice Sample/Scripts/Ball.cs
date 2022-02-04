using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    
   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit(Collision other)
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        

        Debug.Log("Ball hit Ground" + collision.other.name);
    }
    public void OnCollisionStay(Collision other)
    {
        
    }
}


