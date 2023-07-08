using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using FMODUnity;

namespace Game.GameSystem
{
    public class ball_script : MonoBehaviour
    {
        //variable
        [SerializeField] float force;
        //component
        Rigidbody rb;
        // Start is called before the first frame update
        EventReference ballAudio;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            ThrowBall();
            RuntimeManager.PlayOneShot(ballAudio);
        }

        public void ThrowBall()
        {
            rb.AddForce(transform.right * force, ForceMode.Impulse);
        }
        
    }
}
