using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoyMove: MonoBehaviour
{
    //private float countDown = 3;
    //public Text countText;
    public Vector3 jump;
    public float jumpForce;
    private Animator anim;
    private Rigidbody rb;
    Vector3 moveForward;
    private int desiredLane= 1;
    public float laneDistance = 2;
    public bool isJumping = false;
    public float laneSpeed;
    public float moveSpeed;
    public int jumpCount = 0;
    public static int numberOfCoins;
    public TextMeshProUGUI coinText;
    public GameObject effect;
    
    // Start is called before the first frame update
    void Start()
    {
        //countText.text = "3";
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
       
        numberOfCoins = 0;
        
        InvokeRepeating("MoveFaster", 10.0f, 7.0f);
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
            moveForward = new Vector3(0, 0, moveSpeed);
            transform.Translate(moveForward * Time.deltaTime);

            coinText.text = "Points: " + numberOfCoins;
          

            if (SwipeManager.swipeRight)
            {
                desiredLane++;
                Instantiate(effect, transform.position, Quaternion.identity);
                if (desiredLane == 3)
                {
                    desiredLane = 2;
                   
                }
            }

            if (SwipeManager.swipeLeft)
            {
                desiredLane--;
                Instantiate(effect, transform.position, Quaternion.identity);
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
            if(jumpCount < 1)
            {
                if (SwipeManager.swipeUp && isJumping == false)
                {
                    //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                    rb.AddForce(Vector2.up * jumpForce);
                }
            }
           
            if(rb.velocity.y==0)
            {
                anim.SetBool("isJumping", false);
                anim.SetBool("isRunning", true);
                jumpCount = 0;
            }  
            if(rb.velocity.y>0)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                jumpCount = 1;
            }

            if (rb.velocity.y < 0)
            {
                anim.SetBool("isJumping", true);
                anim.SetBool("isRunning", false);
                jumpCount = 1;
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
          
            isJumping = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", true);
        }
    }
    void MoveFaster()
    {
        moveSpeed += 1;
    }


}
