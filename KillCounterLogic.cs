using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCounterLogic : MonoBehaviour
{
    private int counter;

    private string counterColor;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setCounterColor(string color)
    {
        counterColor = color;
    }

}
