using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoSingleton<PlayerCharacter>
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float buttonMashThreshold = 0.1f;
    [SerializeField] float buttonMashMaxScaleFactor = 2.0f;

    [SerializeField] bool isButtonMashing = false;
    [SerializeField] float buttonMashTimer = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //isButtonMashing = true;
            buttonMashTimer = Mathf.Clamp(buttonMashTimer + buttonMashThreshold, 0.0f, buttonMashMaxScaleFactor*buttonMashThreshold);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        /*        if(buttonMashTimer > buttonMashThreshold)
                {
                    buttonMashTimer = 0f;
                }*/
        else if(buttonMashTimer <= buttonMashThreshold)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            //StartCoroutine(ButtonMashCoroutine());
        }
        buttonMashTimer = Mathf.Clamp(buttonMashTimer - (Time.deltaTime* buttonMashTimer), 0.0f, buttonMashMaxScaleFactor*buttonMashThreshold);
        /* // Check if the player is button mashing the "D" key
         if (Input.GetKey(KeyCode.D))
         {
             isButtonMashing = true;
             buttonMashTimer += Time.fixedDeltaTime;
         }
         else
         {
             isButtonMashing = false;
             buttonMashTimer = 0f;
         }

         // Move the player horizontally based on button mashing
         if (isButtonMashing && buttonMashTimer > buttonMashThreshold)
         {
             // Move right
             rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
         }
         else
         {
             // Move left
             rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
         }*/
    }
    /*IEnumerator ButtonMashCoroutine()
    {
        *//*if (Input.GetKey(KeyCode.D))
        {
            isButtonMashing = true;
            //buttonMashTimer += Time.fixedDeltaTime;
        }
        else
        {
            isButtonMashing = false;
            //buttonMashTimer = 0f;
        }
        // Move the player horizontally based on button mashing
        if (isButtonMashing)// && buttonMashTimer > buttonMashThreshold)
        {
            // Move right
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {*//*
            // Move left
*//*        rb.velocity = new Vector2(-0.1f*moveSpeed, rb.velocity.y);
        //}
        isButtonMashing = false;
        yield return new WaitForSeconds(buttonMashThreshold);*//*
    }*/
}
