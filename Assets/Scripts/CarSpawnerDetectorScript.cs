using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerDetectorScript : MonoBehaviour
{
    public CarSpawnerScript carSpawner;
    // Start is called before the first frame update
    void Start()
    {
        carSpawner = GameObject.Find("CarSpawner").GetComponent<CarSpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Car"))
        {
            carSpawner.carSpaceFree = false;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Car"))
        {
            carSpawner.carSpaceFree = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            carSpawner.carSpaceFree = true;
        }
    }

}
