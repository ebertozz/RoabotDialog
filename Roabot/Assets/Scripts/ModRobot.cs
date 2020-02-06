using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModRobot : MonoBehaviour
{
    public GameObject LeftFoot;
    public GameObject RightFoot;
    public GameObject Head;

    public Text tellPlayer;
    public Slider FootSlider;
    public Slider HeadSlider;

    public Sprite HeadImage;
    

    public CanvasGroup CustomizeCanvas;

    public GameObject dialogPanel; // turn this off when game opens


    void Start()
    {
        dialogPanel.SetActive(false);
    }


    public void ChangeFootSize()
    {

        LeftFoot.GetComponent<SpriteRenderer>().sprite = HeadImage;
        tellPlayer.text = "You put a ball on my foot!";
    }

    public void ChangeHeadRotation()
    {
        float newHeadAngle = (HeadSlider.value - 0.5f) * 60;
        Head.transform.eulerAngles = new Vector3(0, 0, newHeadAngle);
        tellPlayer.text = "You tilted my head!";

    }

    public void ClosePanel()
    {
        CustomizeCanvas.alpha = 0f;
        CustomizeCanvas.interactable = false;
        CustomizeCanvas.blocksRaycasts = false;

    }
}
