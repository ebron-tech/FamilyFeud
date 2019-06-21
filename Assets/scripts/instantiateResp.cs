using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class instantiateResp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TMPro.TextMeshProUGUI t= gameObject.GetComponent<TMPro.TextMeshProUGUI>();
		t.text= util.getFolderPathNextToAppFile("rounds");
		Debug.Log("App dataPath Fixed: "+util.getFolderPathNextToAppFile("rounds"));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
