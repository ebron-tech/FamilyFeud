using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource game,resp, ring, fast,win, begin,duplicated,exit, wrong,hitBell, button;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            game.Play();
        }
        if(Input.GetKeyDown(KeyCode.R)){
            button.Play();
        }
        if(Input.GetKeyDown(KeyCode.F)){
            fast.Play();
        }
        if(Input.GetKeyDown(KeyCode.W)){
            win.Play();
        }
        if(Input.GetKeyDown(KeyCode.B)){
            begin.Play();
        }
        if(Input.GetKeyDown(KeyCode.D)){
            duplicated.Play();
        }
        if(Input.GetKeyDown(KeyCode.E)){
            exit.Play();
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            resp.Play();
        }
        if(Input.GetKeyDown(KeyCode.X)){
            wrong.Play();
        }
        if(Input.GetKeyDown(KeyCode.S)){
            stopAllSounds();
        }
        if(Input.GetKeyDown(KeyCode.H)){
            //hitBell.Play();
        }
    }
    public void playSoundType(string soundType){
        switch(soundType){
            case "ring":
                ring.Play();
            break;
            case "fast":
                fast.Play();
            break;
            case "win":
                win.Play();
            break;
            case "begin":
                begin.Play();
            break;
            case "duplicated":
                duplicated.Play();
            break;
            case "exit":
                exit.Play();
            break;
            case "stop":
                stopAllSounds();
            break;
            case "resp":
                resp.Play();
            break;
            case "game":
                game.Play();
            break;
            case "hitBell":
                hitBell.Play();
            break;
            case "wrong":
                wrong.Play();
            break;
            case "button":
                button.Play();
            break;
        }
    }
    void stopAllSounds(){
        game.Stop(); 
        ring.Stop(); 
        fast.Stop(); 
        win.Stop(); 
        begin.Stop(); 
        duplicated.Stop();
        exit.Stop(); 
        game.Stop();
    }
}
