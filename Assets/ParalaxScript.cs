using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -31.84f)
        {
            transform.position = new Vector3(transform.position.x, 31.84f, transform.position.z);
        }
    }
}
