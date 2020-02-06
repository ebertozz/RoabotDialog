using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomRobot : MonoBehaviour
{

	public GameObject FootL;
	public GameObject FootR;
	public GameObject Head;
	public GameObject BigLedge;
	public GameObject HLedge;

	public Slider FootSlider;
	public Slider HeadSlider;

	public Slider LedgeSlider;
	public Sprite HeadImage;

	public CanvasGroup CustomCanvas;

	public GameObject dialogPanel;
	public Text tellPlayer;

   void Start()
    {
		dialogPanel.SetActive(false);   
    }

    public void FootUpdateSlider()
	{
		float newFootValue = FootSlider.value;
		Head.transform.localScale = new Vector2(newFootValue, newFootValue);
		FootL.transform.localScale = new Vector2(newFootValue, newFootValue);
		tellPlayer.text = "Why is only one foot affected?";
	}

	public void HeadUpdateSlider()
	{
		float newHeadVal = (HeadSlider.value - 0.5f) * 10;//shift in scale,, makes the rotation from -30 to 30 

		Head.transform.rotation = new Quaternion(0, 0, 1, newHeadVal);
		HLedge.transform.rotation = new Quaternion(0, 0, 1, newHeadVal);

		tellPlayer.text = "You turned my head and ledge!";
	}

	public void ChangeFootSprite()
	{

		FootL.GetComponent<SpriteRenderer>().sprite = HeadImage;
		tellPlayer.text = "You put a ball on my foot!";
	}

	public void ClosePanel()
    {
		CustomCanvas.alpha = 0f;
		CustomCanvas.interactable = false;

    }

}
