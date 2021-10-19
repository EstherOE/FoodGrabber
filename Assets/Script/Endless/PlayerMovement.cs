using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{

    CharacterController controller;
    Animator anime;
    Rigidbody2D body;
    private Vector3 moveVector;
    public float speed = 5;
    public float jumpSpeed = 3;
    public bool isGround;
    public LayerMask whatisGround;
    private Collider2D collider;

    public float jumpTime;
    private float jumpTimeCounter;
    HealthManager hManager;
    public Vector2 respawnPoint;
    GameManager manager;

    
   
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        manager = FindObjectOfType<GameManager>();
        hManager = FindObjectOfType<HealthManager>();
        jumpTimeCounter = jumpTime;
        sm = FindObjectOfType<ScoreManager>();
        respawnPoint = transform.position;
      
        
    }
    public bool blockRotationPlayer;

    // Update is called once per frame
    void Update()
    {

        if (gameOver == false)
        {
            if(transform.position.x < -20.4f)
            {
                transform.position = new Vector2(-20.4f, transform.position.y);
            }

            if(transform.position.x >15.7f)
            {
                transform.position = new Vector2(15.7f, transform.position.y);
            }

            Animing();
            Movement();

        }

    }
    void Animing()
    {

        anime.SetFloat("Speed", Mathf.Abs(body.velocity.x));
    }
    bool isFacingRight;
    void Movement()
    {
        float direction = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(direction * speed, body.velocity.y);
        if (direction > 0f)
        {
            body.velocity = new Vector2(direction * speed, body.velocity.y);
            isFacingRight = false;
        }
        else if (direction < 0f)
        {
            body.velocity = new Vector2(direction * speed, body.velocity.y);
            isFacingRight = true;
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            isFacingRight = false;
        }


        Flip();
    }

    void Flip()
    {
        if (isFacingRight == true)
        {
            transform.localScale = new Vector2(0.5f,.75f);
        }
        if (isFacingRight == false)
        {
            transform.localScale = new Vector2(-0.5f, .75f);
        }

    }
    public bool gameOver = false;

    ScoreManager sm;

   

    public void OnTriggerEnter2D(Collider2D othern)
    {
        if (othern.tag == "Death")
        {

         
            if(hManager._currenthealth==0)
            {
                gameOver = true;
                manager.gameOver();
                transform.position = new Vector2(-12.2f, -5.11f);

            }
            else
            {
                hManager.killPlayer(5);
                transform.position = respawnPoint;
            }
        }

        if (othern.tag == "Coin")
        {
            
            sm.GetScore(10);
            Destroy(othern.gameObject);
        }
        if (othern.tag == "Diamond")
        {
            sm.GetScore(20);
            Destroy(othern.gameObject);
        }

    }

}


