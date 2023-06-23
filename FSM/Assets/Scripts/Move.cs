using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //reference to the animator component
    //Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    AudioSource audioWalk;
    AudioSource audioJump;

    bool isGrounded;

    [SerializeField]
    Transform groundCheck = null;
    public int speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get the animator component of the GameObject
        //animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        /**
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        audioWalk = allMyAudioSources[0];
        audioJump = allMyAudioSources[1];
        **/
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 3 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        // change the animator's AnimState variable if a key is pressed
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            /**
            if (!isGrounded)
            {
                animator.SetInteger("AnimState", 2);
                audioWalk.Stop();
            }
            else
            {
                if (audioWalk.isPlaying == false)
                {
                    audioWalk.Play();
                }
                animator.SetInteger("AnimState", 1);
            }
            **/
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            /**
            if (!isGrounded)
            {
                animator.SetInteger("AnimState", 2);
                audioWalk.Stop();
            }
            else
            {
                if (audioWalk.isPlaying == false)
                {
                    audioWalk.Play();
                }
                animator.SetInteger("AnimState", 1);
            }
            **/
            rb2d.velocity = new Vector2(0-speed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
        }
        else
        {
            /**
            animator.SetInteger("AnimState", 0);
            audioWalk.Stop();
            **/
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        if (Input.GetKey("up") && isGrounded || Input.GetKey("w") && isGrounded)
        {
            /**
            audioJump.Play();
            animator.SetInteger("AnimState", 2);
            **/
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        }
    }
}