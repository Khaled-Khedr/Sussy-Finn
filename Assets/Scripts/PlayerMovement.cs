using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f; // make it 0 just incase 
    private SpriteRenderer sprite;
    [SerializeField] private float movespeed = 7f; //ser field allows us to change those values directly in unity (convenient and nice)
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround; //ground layer so our player doesnt jump infinitely 

    private enum MovementState {idle,running,jumping,falling} //states 
    MovementState state;
    [SerializeField] private AudioSource jumpSoundEffect; //jumpsound effect audio source
   

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //so we dont execute get component over and over again we place it here
        anim = GetComponent<Animator>(); //same thing as above
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = CrossPlatformInputManager.GetAxis("Horizontal"); //unity input manager  ( 0*7f so we standstill)
        rb.velocity = new Vector2(dirX*movespeed,rb.velocity.y); // so we multiply the direction by a number -ve is left + ve is right (basically instead of an if statement we write this its better

        if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded () )   // executes only when u press space not holding it  ( uses unity system basically same as getkeydown but better )
        {
            jumpSoundEffect.Play(); // plays jump audio when we jump
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //x and y axis rb.velocity.x is the value it has in the previous frame 

        }

        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {

       
        if (dirX > 0f)
        {
            state = MovementState.running;//running state 
            sprite.flipX = false; //flipping the player face to the normal direction


        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; //flipping the player face backwards (basically looking back)

        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f) //0.1f imprecision value 
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -0.1f)
        {
           state = MovementState.falling;
        } //casting enum to int as well so turns enum into an int for unity to process the code

        anim.SetInteger("state", (int)state); //so we tell the animator to set the states according to the conditions we wrote

    }


    private bool isGrounded () //so our player doesnt jump infinite times
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,.1f,jumpableGround); //refer to boxcast documentation
    }


}
