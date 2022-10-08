using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{
    public float moveSpeed;

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;

    public bool IJ;
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;


    private Rigidbody2D rigidbody;
    Animator anim;
    
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    public GameObject RestartBO;
    private ScoreManager theScoreManager;
    float highscore;

    // Start is called before the first frame update
    void Start()
    {
        jumpTimeCounter = jumpTime;
        IJ = false;
        rigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        speedMilestoneCount = speedIncreaseMilestone;
        theScoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        if (transform.position.x > speedMilestoneCount){
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            moveSpeed = moveSpeed * speedMultiplier;
        }

        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded){

                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            }
        }

        // Add jump force time
        if (Input.GetKey (KeyCode.Space))  {
            if (jumpTimeCounter > 0){
                rigidbody.velocity = new Vector2(rigidbody.velocity.x , jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }     
        
        if (Input.GetKeyUp (KeyCode.Space)){
            jumpTimeCounter = 0;
        } 
        if (grounded){
            jumpTimeCounter = jumpTime;
        }
            
        
        anim.SetBool("Grounded", grounded);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground" && IJ==true)
        {
            IJ = false;
            anim.SetBool("IJ", false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            anim.SetBool("Dead", true);
            Time.timeScale = 0;
            theScoreManager.scoreIncreasing = true;
            RestartBO.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("scene1");
        Time.timeScale = 1;
    }
}
