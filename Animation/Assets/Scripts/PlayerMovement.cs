using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 100;
    private Rigidbody rb;
    private Animator animator;




    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        // Freeze rotation to prevent unwanted tilting
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        //read values from keyborad
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move the player

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        if(movement != Vector3.zero)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);

        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            print("Col");
            speed = 40;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            print("Col Exit");
            for(int i = 0; i <  20; i=i+3)
            {
                speed = speed + i;

            }
                

        }
    }
    
}
