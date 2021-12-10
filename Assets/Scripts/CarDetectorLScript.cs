using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetectorLScript : MonoBehaviour
{
    public PlayerScript pS;
    void Start()
    {
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Car"))
        {
            pS.canGoLeft = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Car"))
        {
            //pS.canGoLeft = true;
        }
    }
}
