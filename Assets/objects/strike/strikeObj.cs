using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strikeObj : MonoBehaviour
{
    public float time=4;
    Vector3 lastScale;
    bool animationRunning, endAnimation;
    float localTime;
    Animation anim;
    public void triggerAnimation(){
        gameObject.SetActive(true);
        anim.Play();
        
    }
    public void hide(){
        gameObject.SetActive(false);
    }

    void Start()
    {
        anim=gameObject.GetComponent<Animation>();
    }
    // Update is called once per frame
    void Update()
    {

        
    }
}
