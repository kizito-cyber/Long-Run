using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI countdownTextField;
    
    public static int count;

    void Start()
    {
        StartCoroutine(CountdownCoroutine());
        

    }
     void Update()
    {
       
    }

    IEnumerator CountdownCoroutine()
    {
        countdownTextField.text = "3";
        count = 3;
        yield return new WaitForSeconds(1.0f);
        count--;
        countdownTextField.text = "2";
        yield return new WaitForSeconds(1.0f);
        count--;
        countdownTextField.text = "1";
       
        yield return new WaitForSeconds(1.0f);
        count--;
        countdownTextField.text = "Go!";
        // start the game here
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "";
        yield return null;
    }


}
