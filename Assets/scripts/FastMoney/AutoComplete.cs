using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AutoComplete : MonoBehaviour
{   
    public GameObject empyGO;
    public GameObject anchor;
    List<string> words;
    List<GameObject> VisualWords;
    TMPro.TMP_InputField input;

    void Start(){
        words =new List<string>();
        VisualWords = new List<GameObject>();
        words.Add("Hello");
        words.Add("Darknes");
        words.Add("My");
        words.Add("Old Friend");
        words.Add("Something ");
        words.Add("Else ");
        words.Add("behind the Text");
        input = gameObject.GetComponent<TMPro.TMP_InputField>();
    }
    public void checkRefs(){
        foreach (Transform child in anchor.transform) {
            GameObject.Destroy(child.gameObject);
        }
        Debug.Log(VisualWords.Count);
        VisualWords.Clear();
       List<string> found = words.FindAll( w => w.Contains(input.text) );
       foreach(string s in found){
           instantiateTxt(s);
           
       }
    }
    
    void instantiateTxt(string str){
        
        GameObject auxobj= Instantiate(empyGO,Vector3.zero,Quaternion.identity);
        auxobj.AddComponent<TMPro.TextMeshProUGUI>().text=str;
        auxobj.transform.SetParent(anchor.transform);
        auxobj.transform.position=Vector3.zero;
        VisualWords.Add(auxobj);
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.Return)){
            checkRefs();
        }
    }
}
