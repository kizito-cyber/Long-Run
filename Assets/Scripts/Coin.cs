using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag=="Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");
            BoyMove.numberOfCoins += 1;
            Destroy(gameObject);
            
        }
    }
}
