using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respFastMoney : MonoBehaviour
{
    public TMPro.TextMeshPro respText;
	public TMPro.TextMeshPro respPoints;
	
	Animation rotateShow;
	int points;
    public int status;
    void Start()
    {
           respText.gameObject.SetActive(false);
           respPoints.gameObject.SetActive(false);
    }

    // Update is called once per frame
    bool textIsActive;
    void Update()
    {
        
    }
    public bool showResponse(){
        if(status==0){
            respText.gameObject.SetActive(true);
            status++;
            return false;
        }else if(status==1){
            respPoints.gameObject.SetActive(true);
            status++;
            return true;
        }else{
            respText.gameObject.SetActive(true);
            respPoints.gameObject.SetActive(true);
        }
        
        return false;
    
    }

    public int getPoints(){
            return points;
    }
    public void hideResp(){
        respText.gameObject.SetActive(false);
        respPoints.gameObject.SetActive(false);
    }
    public void setValues(string s, int p){
        respText.text=s;
        points = p;
        respPoints.text = p+"";
        hideResp();
    }
}
