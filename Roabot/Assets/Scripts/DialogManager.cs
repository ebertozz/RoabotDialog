using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
	public Text speakerName;  // field that will show who is speaking
	public Text convoContent;  // field that will show the dialog
	public GameObject dialogPanel;  // reference to the dialog panel so we can make it appear

	private Queue<string> sentences;  //data structure that allow you to only  add items to
									  // end and remove from the beginning (first in first out)

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();    // create our queue from sentences
	}

	public void StartDialog(Dialog dialog)
	{  //method called at start of a conversation
		Debug.Log("talk to " + dialog.name); // check to make sure this works
		speakerName.text = dialog.name; // here we are accessing the elements defined in dialog.cs

		// first need to clear out any previous conversation that might linger in sentences array
		sentences.Clear();

		// then loop through the array and line up each sentence currently in it to prepare 
		foreach (string sentence in dialog.sentences)
		{

			sentences.Enqueue(sentence); // put each in the queue
		}
		// then call a method to actually display it

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{

		// first check to see if we are at the end of convo and if so call end method

		if (sentences.Count == 0)
		{ // if array is empty

			EndConvo(); // call end method
			return;     // leave the function
		}
		string sentence = sentences.Dequeue();  // otherwise pull sentence out of the queue
		convoContent.text = sentence;
		//Debug.Log ("line is" + sentence); // display it

	}

	public void EndConvo()
	{
		Debug.Log("reached end of convo");
		dialogPanel.SetActive(false);

	}
}
