using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoSingleton<PlayerCharacter>
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float buttonMashThreshold = 0.1f;
    [SerializeField] float buttonMashMaxScaleFactor = 2.0f;
    //life field
    [SerializeField] private int _lives;
    [SerializeField] GameObject defeatPanel;
    //bool to keep track of whether player is moving forward
    [SerializeField] bool isMovingForward = false;
    int maxLives;
    //life property because it seems like better practice than just having it as a field and also satisfies principle of encapsulation. Should probably refactor previous stuff as well as a stretch goal
    public int Lives 
    { 
        get
        {
            return _lives;
        } 
        set 
        {
            _lives = value; 
        } 
    }
    [SerializeField] float buttonMashTimer = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //variable used to keep track of maximum number of lives is set to number of Lives at start of play
        maxLives = Lives;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            buttonMashTimer = Mathf.Clamp(buttonMashTimer + buttonMashThreshold, 0.0f, buttonMashMaxScaleFactor*buttonMashThreshold);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            //set move forward bool to true
            isMovingForward = true;
        }
        else if(buttonMashTimer <= buttonMashThreshold)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            //set move forward bool to false
            isMovingForward = false;
        }
        if(isMovingForward)
        {
            //set Game Manager animator to cause the player's walk animation to play
            GameManager.Instance.animator.SetBool("isWalking", true);
            GameManager.Instance.animator.SetBool("isLyingDown", false);
        }
        else
        {
            //set Game Manager animator to cause the player's walk animation to stop playing
            GameManager.Instance.animator.SetBool("isWalking", false);
        }
        buttonMashTimer = Mathf.Clamp(buttonMashTimer - (Time.deltaTime* buttonMashTimer), 0.0f, buttonMashMaxScaleFactor*buttonMashThreshold);
    }
    //method that can be called using the Player Character's Instance to decrement a life
    public void DecrementLives()
    {
        //clamp life value between 0 and max
        Mathf.Clamp(Lives--, 0, maxLives);
        //set Game Manager animator to cause the player to lie down
        GameManager.Instance.animator.SetBool("isLyingDown", true);
        //set move forward bool to false
        isMovingForward = false;
    }
    //method that can be called using the Player Character's Instance to increment a life
    public void IncrementLives()
    {
        //clamp life value between 0 and max
        Mathf.Clamp(Lives++, 0, maxLives);
    }
    //method that checks if lives are 0 and enables defeat panel if so and pauses the game
    public void CheckForLoss()
    {
        if(Lives <= 0)
        {
            defeatPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    
}
