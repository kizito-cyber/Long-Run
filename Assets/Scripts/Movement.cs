using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Vector3 addForce;
    Vector3 addForceLeft;
    Vector3 addForceRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addForce = new Vector3(0, 0, 30);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(addForce, ForceMode.Acceleration);
       
    }
}
