using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

[CreateAssetMenu(fileName ="VoiceDict", menuName = "My Project/VoiceDict")] 
public class VoiceDict : ScriptableObject
{
    public Transform k;
    public static VoiceDict ins;
    // Start is called before the first frame update
    void Start()
    {
        ins = this;

    }
    

    // Update is called once per frame
   
}
