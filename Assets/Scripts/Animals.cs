using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    public float speed = 20;
    public float rotationSpeed = 45;
    public float jumpForce = 1000;
    private bool canJump;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();

        FindAnimalType();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Abstraction
        Rotate();
        Walk();
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void Walk()
    {
        // Abstraction
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        
    }

    private void Rotate()
    {
        // Abstraction
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);       

    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }  
    }

    private void FindAnimalType()
    {
        // Uses Polymorphism and Inheritance
        if (MainManager.instance.animalName == "Dog")
        {
            speed = 30;
            jumpForce = 150;
            rend.material.color = Color.white;

        }
        else if (MainManager.instance.animalName == "Cat")
        {
            speed = 25;
            jumpForce = 175;
            rend.material.color = Color.black;

        }
        else if (MainManager.instance.animalName == "Cow")
        {
            speed = 15;
            jumpForce = 200;
            rend.material.color = Color.yellow;

        }
        else if (MainManager.instance.animalName == "Rabbit")
        {
            speed = 35;
            jumpForce = 125;
            rend.material.color = Color.blue;

        }
        else
        {
            speed = 20;
            jumpForce = 100;

        }
    }
}
