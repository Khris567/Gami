using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject passPrefab;
    public GameObject biciclePrefab;
    public PlayerScript playerScript;
    public TraficScript traficScript;
    public float passValue;
    public bool carSpaceFree;
    public bool creatingFreeSpace;
    public bool spawnPass;
    public int rngLimit;

    public float spaceTimer;

    int i;
    public GameObject[] velocistas;
    void Start()
    {
        carSpaceFree = true;
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        traficScript = GameObject.Find("TrafficSpeedManaguer").GetComponent<TraficScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(carSpaceFree)
        {
            if(!creatingFreeSpace)
            {
                if (playerScript.onCiclovía)
                {
                    if(!spawnPass)
                    {
                        CarSpawn();
                    }
                    else
                    {
                        PassSpawn();
                        spawnPass = false;
                    }

                    
                }

            }
            
        }
    }

    public void CarSpawn()
    {
        GameObject SpawnedCar = Instantiate(carPrefab,gameObject.transform);
        SpawnedCar.GetComponent<CarScript>().carSpeed = traficScript.actualSpeedUp;
        agregarVelocista(SpawnedCar);
        carSpaceFree = false;
        passValue = Random.Range(0, 20);
        if(passValue <rngLimit)
        {
            spawnPass = true;
            StartCoroutine(FreeSpace());
            Debug.Log("lo llame");
        }
        
    }
    public void PassSpawn()
    {
        GameObject SpawnedPass = Instantiate(passPrefab, gameObject.transform);
        GameObject SpawnedBicicle = Instantiate(biciclePrefab);
        SpawnedBicicle.GetComponent<CarScript>().carSpeed = traficScript.actualSpeedUp * 0.9f;
        SpawnedPass.GetComponent<CarScript>().carSpeed = traficScript.actualSpeedUp;
        agregarVelocista(SpawnedPass);

        carSpaceFree = false;
        creatingFreeSpace = true;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            carSpaceFree = false;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            carSpaceFree = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {
            carSpaceFree = true;
        }
        if(collision.CompareTag("Pass"))
        {
            //carSpaceFree = true;
        }
    }

    public void agregarVelocista(GameObject agregor)
    {
  
        traficScript.velocistas.Add(agregor);
    }
    IEnumerator FreeSpace()
    {
        
        yield return new WaitForSeconds(spaceTimer);
        creatingFreeSpace = false;
        spawnPass = false;
        carSpaceFree = true;
        Debug.Log("Me llamaron");


    }


}
