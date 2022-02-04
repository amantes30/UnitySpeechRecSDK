using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit(Collision other)
    {

    }
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Stick hit Ground" + other.other.name);
    }
    public void OnCollisionStay(Collision other)
    {

    }
}
