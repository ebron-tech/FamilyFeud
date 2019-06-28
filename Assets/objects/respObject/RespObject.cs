using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespObject : MonoBehaviour {

	public TMPro.TextMeshPro respText;
	public TMPro.TextMeshPro respPoints;
	public TMPro.TextMeshPro respIndex;
	public GameObject indexContainer;
	Animation rotateShow;
bool activated;
	void Awake(){
		rotateShow = gameObject.GetComponent<Animation>();
	}
	public void setValues(int id, string resp, int points){
		respText.text = resp;
		respPoints.text=points+"";
		respIndex.text= id+"";
		respText.gameObject.SetActive(false);
		respPoints.gameObject.SetActive(false);
	}
	public void showResponse(){
		if(!activated){
			respText.gameObject.SetActive(true);
			respPoints.gameObject.SetActive(true);
			rotateShow.Play();
			activated=true;
		}
	}
	void Update () {
		
	}
	public void hideId(){
		indexContainer.SetActive(false);
	}
}
