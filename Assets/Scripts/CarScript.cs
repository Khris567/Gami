using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public PlayerScript pS;
    public float carSpeed;
    public bool chosenOne;
    public TraficScript traficScript;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pS = GameObject.Find("Player").GetComponent<PlayerScript>();
        traficScript = GameObject.Find("TrafficSpeedManaguer").GetComponent<TraficScript>();
    }

    void Update()
    {
        if (pS.onCiclovía)
        {
            rb2d.velocity = new Vector2(0f, -carSpeed);
        }
        else
        {
            if (!chosenOne)
            { 
            rb2d.velocity = new Vector2(0f, 0f);
            }
        } 

        if(transform.position.y<-50 )
        {
            Destroy(gameObject);
        }
        
    }

    void UpdateSpeed()
    {
        
    }
}
