using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Windows;
using System.Linq;

public class VoiceMove : MonoBehaviour
{
    
    public Animator anim;
    public Canvas HelpMenu;
    public Transform Human;

    [SerializeField] Transform Environment;
    public List<Transform> HoldableObjs;

    private KeywordRecognizer playermovement_keywords;
    Vector3 speed, direction;




    //dictionary to save Keywords
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

   
    // Start is called before the first frame update
    void Start()
    {

        // add keywords to the dictionary
        actions.Add("walk", Walk);
        actions.Add("turn right", TurnRight);
        actions.Add("turn left", TurnLeft);
        actions.Add("stop", Stopp);
        actions.Add("run", Run);
        actions.Add("hello", Greet);
        actions.Add("do backflip", flip);
        actions.Add("jump", Jump);


        playermovement_keywords = new KeywordRecognizer(actions.Keys.ToArray());

        playermovement_keywords.OnPhraseRecognized += WhenRecognized;
        playermovement_keywords.Start();

      
        anim = Human.GetComponent<Animator>();



        // Get's animation component attached on object

        foreach (Transform i in Environment.GetComponentInChildren<Transform>())
        {
            if (i.tag == "Pickable")
            {
                HoldableObjs.Add(i);
            }
        }

    }

    void Jump()
    {
        PlayAnim("Jumped");

    }
    void PlayAnim(string a)
    {

        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("BackFlip", false);
        anim.SetBool("Greet", false);
        anim.SetBool("Jumped", false);


        anim.SetBool(a, true);
    }
    void BeIdle()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("isWalking", false);
        anim.SetBool("BackFlip", false);
        anim.SetBool("Greet", false);
        speed = Vector3.zero;
    }
    private void flip() => PlayAnim("BackFlip");
    private void Greet() => PlayAnim("Greet");
    void Run()
    {
        PlayAnim("isRunning");
        speed = Vector3.forward * 0.1f;
    }
    void Stopp() => BeIdle();

    void TurnLeft() => Human.transform.Rotate(0, -90, 0);

    void TurnRight() => Human.transform.Rotate(0, 90, 0);

    void Walk()
    {
        PlayAnim("isWalking");
        speed = Vector3.forward * 0.01f;
    }

    private void WhenRecognized(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (!HelpMenu.gameObject.activeInHierarchy)
            {
                HelpMenu.gameObject.SetActive(true);
                HelpMenu.transform.GetChild(0).GetComponent<Animation>().Play();
            }

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            HelpMenu.gameObject.SetActive(false);
        }
        Human.Translate(speed);

    }


}

