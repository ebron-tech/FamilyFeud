using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using round;
public class instantiateResp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TMPro.TextMeshProUGUI t= gameObject.GetComponent<TMPro.TextMeshProUGUI>();
		t.text= util.getFolderPathNextToAppFile("rounds");
		Debug.Log("App dataPath Fixed: "+util.getFolderPathNextToAppFile("rounds"));
		
		Round[] rounds = util.getRoundsFromFolder("rounds");
		foreach(Round r in rounds){
			foreach(RoundElement re in r.Rounds){
			Debug.Log(re.Question);
			
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
