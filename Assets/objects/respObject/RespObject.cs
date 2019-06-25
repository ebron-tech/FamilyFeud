using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespObject : MonoBehaviour {

	public TMPro.TextMeshPro respText;
	public TMPro.TextMeshPro respPoints;
	public TMPro.TextMeshPro respIndex;
	Animation rotateShow;

	void Awake(){
		rotateShow = gameObject.GetComponent<Animation>();
	}
	void setValues(int id, string resp, int points){
		respText.text = resp;
		respPoints.text=points+"";
		respIndex.text= id+"";
		respText.gameObject.SetActive(false);
		respPoints.gameObject.SetActive(false);
	}
	void showResponse(){
		respText.gameObject.SetActive(true);
		respPoints.gameObject.SetActive(true);
		rotateShow.Play();
	}
	void Update () {
		
	}
}
