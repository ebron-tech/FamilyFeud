using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnwswerContainer : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    public TMPro.TextMeshProUGUI question;
    public TMPro.TMP_InputField textField;
    public UnityEngine.UI.Button button;
    KeyCode keyPressed;
    DashboardSendOSC sendOSC;
    public AutoComplete completeController;
    void Update(){
        if(Input.GetKeyDown(keyPressed)){
            showResp();
        }
    }
    void Start(){
        int localID=((id+1==10)?0:(id+1));
        keyPressed = (KeyCode) System.Enum.Parse(typeof(KeyCode), "Alpha"+ localID) ;
        sendOSC = GameObject.FindObjectOfType<DashboardSendOSC>();
        button.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text="show"+localID;
        button.interactable=false;
    }
    public void showResp(){
        //txtAnswer.color=Color.white;
        if(button.interactable==true && !completeController.isTextInputSelected){
            textField.gameObject.GetComponent<UnityEngine.UI.Image>().color= Color.green;
            sendOSC.selectAnswr(id+1);
            Debug.Log("buttonpressed:"+ id+1);
        }
    }
}
