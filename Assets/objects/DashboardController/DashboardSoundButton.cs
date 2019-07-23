using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardSoundButton : MonoBehaviour
{
    public string sKeyDown, soundType;
    KeyCode keyPressed;
    DashboardSendOSC sendOSC;
    void Start()
    {
        keyPressed = (KeyCode) System.Enum.Parse(typeof(KeyCode), sKeyDown.ToUpper() ) ;
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyPressed)){
            triggerSound();
        }
    }
    public void triggerSound(){
         sendOSC.soundAction(soundType);
    }
}
