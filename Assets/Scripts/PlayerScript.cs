using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float leftPos;
    public float rightPos;
    public bool onCiclovía;
    public bool canGoLeft;
    public bool touched;
    public GameObject logo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TapMove();
    }

    void TapMove()
    {
        if (Input.GetMouseButtonDown(0)||( Input.touchCount > 0 && !touched))
        {
            touched = true;
            Destroy(logo);
            if (onCiclovía)
            {
                if(canGoLeft)
                {
                    transform.position = new Vector3(leftPos, transform.position.y, transform.position.z);
                    onCiclovía = false;
                }                
            }
            else
            {
                transform.position = new Vector3(rightPos, transform.position.y, transform.position.z);
                onCiclovía = true;
            }
        }
        if(Input.touchCount ==0)
        {
            touched = false;
        }
    }

    public void EndGame()
    {
        Debug.Log("Termino el juego Papuh");
        SceneManager.LoadScene("EndScene");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            canGoLeft = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bicicle"))
        {
            EndGame();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Pass"))
        {
            canGoLeft = true;
        }
    }

    void Trafic()
    {

    }
}
