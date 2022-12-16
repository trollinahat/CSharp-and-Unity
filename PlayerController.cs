using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Vector2 movement;
    private BoxCollider2D boxCollider;
    public float walkSpeed;
    public Vector2 playerStartLocation;
    private KillCounterLogic counterLogic;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();
    }

    private void Awake() 
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerStartLocation = body.position;        
    }

    void CalculateMovement()
    {
        Vector2 currentPos = body.position;

        Vector2 adjustedMovement = movement * walkSpeed;

        Vector2 newPos = currentPos + adjustedMovement *Time.fixedDeltaTime;

        body.MovePosition(newPos);
    }

    void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            //deal 10 damage to overlapped enemy -- simulate melee combat
            other.gameObject.GetComponent<Health>().takeDamage(10);

            //INCOMPLETE LOGIC
            //IF THE ENEMY DIES ets the counter color based on the this killed enemy
            //Counter + 1
            counterLogic.setCounterColor(other.gameObject.GetComponent<ColorIdentity>().getColorIdentity());
        }
    }
}
