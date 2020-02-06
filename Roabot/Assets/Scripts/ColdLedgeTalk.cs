using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdLedgeTalk : MonoBehaviour
{

    DialogTrigger dialogTrigger;// reference to trigger script on this object
    public GameObject dialogPanel; // reference to panel so we can turn on

    public bool onCold = false; // bool set from the MoveBot script
    bool beganDialog = false;


    // Start is called before the first frame update
    void Start()
    {
        dialogTrigger = GetComponent<DialogTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(onCold == true && beganDialog == false)
        {
            startTalking();
            
        }
    }

    void startTalking()
    {
        beganDialog = true;
        dialogPanel.SetActive(true);
        dialogTrigger.TriggerDialog();

    }
}
