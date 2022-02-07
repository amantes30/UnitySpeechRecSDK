using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Windows;
using System.Linq;
using UnityEngine.UI;

public class VoiceListener : MonoBehaviour
{
    [SerializeField] private Animator AnimationController;
    [SerializeField] private Canvas HelpMenu;
    [SerializeField] private Transform HumanModel;
    [SerializeField] Transform Environment;
    [SerializeField] Transform ObjectInHand;
    public List<Transform> HoldableObjs; // list to get every object that player can hold in the scene
    private KeywordRecognizer playermovement_keywords; //Keyword to be recognized
    Vector3 speed; // for player movement
                   //dictionary to save Keywords with functions
    [SerializeField] private Text MicCheckText;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform obj in Environment.GetComponentInChildren<Transform>())
        {
            if (obj.tag == "Pickable")
            {

                HoldableObjs.Add(obj);
                if (obj.name.Split('_')[0] == "ball")
                {
                    obj.gameObject.AddComponent<Ball>();
                }
                else if (obj.name.Split('_')[0] == "stick")
                {
                    obj.gameObject.AddComponent<Stick>();
                }
            }
            else if (obj.tag == "Player")
            {
                HumanModel = obj;
            }
        }
        AnimationController = HumanModel.GetComponent<Animator>();
        // add keywords to the dictionary
        actions.Add("walk", Walk);
        actions.Add("turn right", TurnRight);
        actions.Add("turn left", TurnLeft);
        actions.Add("stop", Stopp);
        actions.Add("run", Run);
        actions.Add("hello", Greet);
        actions.Add("do backflip", flip);
        actions.Add("jump", Jump);
        actions.Add("hold ball", HoldBall);
        actions.Add("throw ball", ThrowBall);
        actions.Add("deactivate voice control", VoiceOff);

        playermovement_keywords = new KeywordRecognizer(actions.Keys.ToArray());

        playermovement_keywords.OnPhraseRecognized += WhenRecognized;
        playermovement_keywords.Start();






        // Get's animation component attached on object

    }
    public void VoiceOff()
    {
        HumanModel.transform.GetComponent<KeyboardMove>().enabled = true;
        string[] s = MicCheckText.text.Split(' ');
        s[1] = "OFF";
        MicCheckText.text = string.Join(" ", s);
        transform.GetComponent<KeyboardMove>().enabled = false;
        transform.GetComponent<VoiceListener>().enabled = false;

    }
    void HoldBall()
    {
        if (ObjectInHand.name == "ball") { return; }
        else
        {
            foreach (Transform i in HoldableObjs)
            {
                if (i.name == "ball")
                {
                    i.GetComponent<Rigidbody>().useGravity = false;
                    ObjectInHand = i;
                    ObjectInHand.SetParent(HumanModel);
                    i.localPosition = new Vector3(0.18f, 0.95f, 0.26f);
                    i.localRotation = Quaternion.identity;


                }
            }
        }
    }
    void ThrowBall()
    {
        ObjectInHand.GetComponent<Rigidbody>().useGravity = true;
        ObjectInHand.GetComponent<Rigidbody>().AddForce(0, 0, 50);
        ObjectInHand.SetParent(Environment);
    }
    void Jump()
    {
        PlayAnim("Jumped");
        HumanModel.GetComponent<Rigidbody>().AddForce(Vector3.up * 15f);

    }
    void PlayAnim(string a)
    {

        AnimationController.SetBool("isRunning", false);
        AnimationController.SetBool("isWalking", false);
        AnimationController.SetBool("BackFlip", false);
        AnimationController.SetBool("Greet", false);
        AnimationController.SetBool("Jumped", false);


        AnimationController.SetBool(a, true);

    }
    void BeIdle()
    {
        AnimationController.SetBool("isRunning", false);
        AnimationController.SetBool("isWalking", false);
        AnimationController.SetBool("BackFlip", false);
        AnimationController.SetBool("Greet", false);
        AnimationController.SetBool("Jumped", false);
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

    void TurnLeft() => HumanModel.transform.Rotate(0, -90, 0);

    void TurnRight() => HumanModel.transform.Rotate(0, 90, 0);

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
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.C))
        {

            if (!HelpMenu.gameObject.activeInHierarchy)
            {
                HelpMenu.gameObject.SetActive(true);
                HelpMenu.transform.GetChild(0).GetComponent<Animation>().Play();
            }

        }
        if (Input.GetKey(KeyCode.Escape) && HelpMenu.isActiveAndEnabled)
        {
            HelpMenu.gameObject.SetActive(false);
        }
        HumanModel.Translate(speed);

    }

}
