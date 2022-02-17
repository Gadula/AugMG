using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject doorWing;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Door")
        {
        
            doorWing.transform.Rotate(0, 135, 0);

        }
        
    }

    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        if (other.name == "Door")
        {

            doorWing.transform.Rotate(0, -135, 0);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
