using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // The duration of a match
    public float duration = 600;

    // The visual timer representation

    
    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime; 

        if (duration <=0)
        {
            duration = 0;
        
            enabled = false;

        }


        

    }
}
