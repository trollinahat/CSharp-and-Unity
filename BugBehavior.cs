using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    private SpriteRenderer SpriteRenderer;
    BoxCollider2D box;
    public bool overlappingcharacter;


    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void FixedUpdate() 
    {

    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

}
