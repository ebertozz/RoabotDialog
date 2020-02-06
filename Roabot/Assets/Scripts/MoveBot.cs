using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour
{

    float runSpeed = 2;// float to control speed
    float jumpForce = 300; // float for jump force
    Animator myAnimator; // reference to our attached animator
    public bool grounded = false; // create a bool to track grounded

    public GameObject groundCheck = null;// reference to the ground check object that we are raycasting to
     public bool imHigh = false; // bool to track if I am on the cold platform
  
    public ColdLedgeTalk coldLedgeTalk; // create a slot in inspector for object with script so we can
    // change status of bool


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();// connect reference to object
      
       
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawLine(transform.position, groundCheck.transform.position, Color.yellow);
        if (Physics2D.Linecast(transform.position, groundCheck.transform.position))
            // showing us the line drawn between center of avatar and groundcheck
        {
            grounded = true; // if there is a hit on our linecast we are on a platform - set grounded to true
            RaycastHit2D hitPlatform = Physics2D.Linecast(transform.position, groundCheck.transform.position); // name the object we are hitting hitplatform
            if (hitPlatform.collider.name == "HotLedge")
            { // if the name of the hitplatform object is greenbox

               
                imHigh = true; // set the bool that we will send to animator


            }
            else if (hitPlatform.collider.name == "ColdLedge")
            {// if the hitplatform is cold ledge, set the bool in that script for dialog
                coldLedgeTalk.onCold = true;
               

            }
        }
        else
        {
            grounded = false;
            coldLedgeTalk.onCold = false;
            imHigh = false;
            //if we aren't hitting any platform, set all bools to false
        }

        myAnimator.SetBool("isHigh", imHigh);
       
        myAnimator.SetBool("Grounded", grounded);// tell the animator to set the bool to true


        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;// create a float tracking current Y velocity

        if (Input.GetKey(KeyCode.LeftArrow)) // if player presses left arrow
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
            // set velocity of robot
            transform.localScale = new Vector2(-1, transform.localScale.y);
            // make sure facing current
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
            transform.localScale = new Vector2(1, transform.localScale.y);

        } else if (Input.GetKeyDown(KeyCode.UpArrow)&& grounded)
        {

            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce)); // actually jump
            myAnimator.SetTrigger("Jump");

        }
    }
}
