using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentController : MonoBehaviour
{
   public float agent_speed = 10;
    public float agent_jump = 1;
    private bool jumping = true;
    public bool restart = false;
    private Vector3 zero = new Vector3 (0.0f, 0.0f, 0.0f);

   void FixedUpdate ()
   {
       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       Rigidbody rb = GetComponent<Rigidbody>();

       
       if (jumping == false && Input.GetKey(KeyCode.Space)) {
           rb.AddForce(0, agent_jump, 0, ForceMode.Impulse);
           jumping = true;
       }else
       {
           rb.AddForce(x*agent_speed, 0, z*agent_speed);
       }
       if (rb.position.y < -30){
           restart = true;
       }
        if (restart){
            rb.position = zero + Vector3.up*2;
            rb.angularVelocity = zero;
            restart = false;
            jumping = true;
        }
   }

   void OnCollisionEnter(Collision hit)
   {
       jumping = false;

       if (hit.gameObject.tag == "Traps")
       {
           restart = true;
       }  
       if (hit.gameObject.tag == "Food")     
       {
           Destroy(hit.gameObject);
       }
   }  
}
