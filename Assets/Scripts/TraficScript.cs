using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraficScript : MonoBehaviour
{
    public List<GameObject> velocistas;
    public float speedUpTimer;
    float originalSpeedUpTimer;
    public float speedUpRatio;
    public float actualSpeedUp;
    static float carSpeed;
    public CarSpawnerScript carSpawnerScript;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        actualSpeedUp = 8;
        originalSpeedUpTimer = speedUpTimer;
    }

    // Update is called once per frame
    void Update()

    {
        
        speedUpTimer -= Time.deltaTime;
        if(speedUpTimer<= 0)
        {
            actualSpeedUp *= 1.2f;
            carSpawnerScript.spaceTimer *= 0.8f;

            for (i = 0; i < velocistas.Count; i++)
            {
                if (velocistas[i] != null)
                {
                    velocistas[i].GetComponent<CarScript>().carSpeed = actualSpeedUp;
                }
            }
            speedUpTimer = originalSpeedUpTimer;

        }
        
    }

}
