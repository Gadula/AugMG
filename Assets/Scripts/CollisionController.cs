using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "doorWing")
        {
            other.transform.Rotate(0, 135, 0);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
