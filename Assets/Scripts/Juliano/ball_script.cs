using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_script : MonoBehaviour
{
    //variable
    [SerializeField] float force;
    //component
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowBall()
    {
        rb.AddForce(transform.right * force, ForceMode.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
