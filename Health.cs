using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health;
    public int maxHealth;
    public GameObject character;

    string characterColor;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        characterColor = character.GetComponent<ColorIdentity>().getColorIdentity();
    }

    // Update is called once per frame
    void Update()
    {
         if(health <=0)
        {
            if (character.tag == "Player")
            {
                //END GAME
            }
            else
            {
                Destroy(character);
            }
        }
    }

    public int getHealth()
    {
        return health;
    }

    public int takeDamage(int damageAmount)
    {
        health -= damageAmount;
        return health;
    }
}
