using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespObject : MonoBehaviour {

	public TMPro.TextMeshPro respText;
	public TMPro.TextMeshPro respPoints;
	public TMPro.TextMeshPro respIndex;
	public GameObject indexContainer;
	Animation rotateShow;
	int points;
bool activated;
	void Awake(){
		rotateShow = gameObject.GetComponent<Animation>();
	}
	public void setValues(int id, string resp, int pnts){
		respText.text = resp;
		respPoints.text=pnts+"";
		respIndex.text= id+"";
		respText.gameObject.SetActive(false);
		respPoints.gameObject.SetActive(false);
		points=pnts;
	}
	public bool showResponse(){
		if(!activated){
			respText.gameObject.SetActive(true);
			respPoints.gameObject.SetActive(true);
			rotateShow.Play();
			activated=true;
			return true;
		}
		return false;
	}
	public int getPoints(){
		return points;
	}
	void Update () {
		
	}
	public void hideId(){
		indexContainer.SetActive(false);
	}
}
