using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateResp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TMPro.TextMeshProUGUI t= gameObject.GetComponent<TMPro.TextMeshProUGUI>();
		t.text= util.getFolderDataPath("rounds");
		Debug.Log("App dataPath Fixed: "+util.getFolderDataPath("rounds"));
		Debug.Log("Files:");
		string[] filePaths = util.getDataFilesFromPath("rounds");
		foreach(string file in filePaths){
			Debug.Log("\t"+file);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
