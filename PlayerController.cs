using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    private SpriteRenderer SpriteRenderer;
    private Vector2 Movement;
    private BoxCollider2D box;
    public float WalkSpeed;

    public GameObject parasite;
    private Rigidbody2D parasiteBody;
    private Vector2 parasiteCurrentPos;

    public int playerHealth;
    public int parasiteHealth;
    public int maxHealth = 10;

    public bool parasiteAttached;
   // private bool closeToParasite;

    public Vector2 playerStart;
    public Vector2 parasiteStart;

    // Start is called before the first frame update
    void Start()
    {
        //set default health values on start/spawn
        playerHealth = maxHealth;
        parasiteHealth = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        parasiteBody = parasite.GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        playerStart = body.position;
        parasiteStart = parasiteBody.position;

    }

    void FixedUpdate() 
    {
        CalculateMovement();

        if(parasiteAttached)
        {
            FollowingPlayer();
            
        }

        //Player and Parasite Health Logic
        if (playerHealth <= 0)
        {
            Object.Destroy(this);
            QuitGame();
        }

        if (parasiteHealth <= 0)
        {
            Object.Destroy(parasite);
            QuitGame();
        }
    }

    //Player Movement Logic
    void CalculateMovement()
    {
        Vector2 currentPos = body.position;

        Vector2 adjustedMovement = Movement * WalkSpeed;

        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;

        body.MovePosition(newPos);
    }

    //onMove Input
    void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

    //onCandleDetachBug Input
    void OnCandleDetachParasite(InputValue value)
    {
        parasiteAttached = false;
        StopAllCoroutines();
        StartCoroutine(CalculateDetachedHealth(1));
    }
    
    //onPickupBug Input -- works only if character is next to parasite
    void OnPickupParasite(InputValue value)
    {
        //if distance between parasite and body is close....could be done on overlap with player box searching for parasite

        //float distance = float(parasiteBody.position - body.position);
        parasiteAttached = true;
        parasiteBody.MovePosition(body.position);
        StopAllCoroutines();
        StartCoroutine(CalculateAttachedHealth(1));
    }

    //Make Parasite Follow Player
    void FollowingPlayer()
    {
        parasiteBody.MovePosition(body.position);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #endif

        Application.Quit();
    }

    IEnumerator CalculateAttachedHealth(int DPS)
    {
        while(parasiteAttached){
            playerHealth -= DPS;
            parasiteHealth += DPS;
            yield return new WaitForSeconds(1.0f);
        }
    }   

    IEnumerator CalculateDetachedHealth(int DPS)
    {
        while(!parasiteAttached)
        {
            parasiteHealth -= DPS;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Food")
        {
            playerHealth +=5;
            Destroy(other.gameObject);
        }
    }

}

