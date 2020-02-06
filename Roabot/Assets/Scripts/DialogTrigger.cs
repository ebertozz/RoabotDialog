using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
	public Dialog dialog;  // find the Dialog script and create a reference to it.

	public void TriggerDialog()
	{
		FindObjectOfType<DialogManager>().StartDialog(dialog);// looks for the script and calls function
        // using the specific text from the object it was called from

	}
}
