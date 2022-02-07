using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardMove : MonoBehaviour
{
    [SerializeField] private VoiceListener VoiceListener;
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;

    [SerializeField] private Text MicCheckText;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        sensitivity = 15f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (y > 0)
        {
            transform.GetComponent<Animator>().SetBool("isWalking", true);
        }
        if (y == 0)
        {
            transform.GetComponent<Animator>().SetBool("isWalking", false);
            transform.GetComponent<Animator>().SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.GetComponent<Animator>().SetBool("isRunning", true);

            speed = 0.1f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.GetComponent<Animator>().SetBool("isRunning", false);
            speed = 0.05f;
        }

        if (Input.GetKey(KeyCode.V))
        {
            VoiceListener.GetComponent<VoiceListener>().enabled = true;
            string[] s = MicCheckText.text.Split(' ');
            s[1] = "ON";
            MicCheckText.text = string.Join(" ", s);
            transform.GetComponent<KeyboardMove>().enabled = false;
            
        }
        transform.Translate(x*speed,0, y*speed);
        transform.Rotate(transform.rotation.x, x * sensitivity, transform.rotation.z);

        
    }
}
