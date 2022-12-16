using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIdentity : MonoBehaviour
{
    public bool isBlue;
    public bool isGreen;
    public bool isRed;
    public string colorIdentity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string getColorIdentity()
    {
        if (isBlue)
        {
            colorIdentity = "Blue";
        }
        if (isGreen)
        {
            colorIdentity = "Green";
        }
        else
        {
            colorIdentity = "Red";
        }
        return colorIdentity;
    }
}
