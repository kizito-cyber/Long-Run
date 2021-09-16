using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMovement : MonoBehaviour
{
    //private float countDown = 3;
    //public Text countText;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    private Animator anim;
    private Rigidbody rb;
    Vector3 moveForward;
    private int desiredLane= 1;
    public float laneDistance = 2;
    public bool isJumping = false;
    public float laneSpeed;
    public float moveSpeed; 
   
    // Start is called before the first frame update
    void Start()
    {
        //countText.text = "3";
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        moveForward = new Vector3(0, 0, moveSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.count<=3)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
        }
        if(Timer.count==0)
        {
            //countDown = countDown -- * Time.deltaTime; 
            //countDown = ((int)countDown);
            //countText.text = countDown.ToString();
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
            //transform.Translate(moveForward * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                if (desiredLane == -1)
                {
                    desiredLane = 0;
                }
            }
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (desiredLane == 0)
            {
                targetPosition += Vector3.left * laneDistance;
            }
            else if (desiredLane == 2)
            {
                targetPosition += Vector3.right * laneDistance;
            }
            transform.position = Vector3.Lerp(transform.position, targetPosition, laneSpeed * Time.deltaTime);

            if(Input.GetKeyDown(KeyCode.UpArrow)&&isJumping==false&& isGrounded==true)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
                isJumping = true;
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            isGrounded = true;
            isJumping = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }
    }


}
