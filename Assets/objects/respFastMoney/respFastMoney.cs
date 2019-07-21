using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respFastMoney : MonoBehaviour
{
    public TMPro.TextMeshPro respText;
	public TMPro.TextMeshPro respPoints;
	
	Animation rotateShow;
	int points;
    int status;
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
        }else if(status==1){
            respPoints.gameObject.SetActive(true);
        }else{
            return false;
        }
        status++;
        return true;
    }

    public int getPoints(){
        if(status>0){
            return points;
        }else{
            return 0;
        }
    }

    public void setValues(string s, int p){
        respText.text=s;
        points = p;
        respPoints.text = p+"";
    }
}
