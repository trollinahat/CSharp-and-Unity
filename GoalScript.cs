using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D triggerBox;


    // Start is called before the first frame update
    void Start()
    {
        triggerBox = GetComponent<BoxCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {    

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Parasite")
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
