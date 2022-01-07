using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transportation : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.name != "AR Camera")
            return;

        //outside of other world
        if (transform.position.z > other.transform.position.z)
        {
            foreach (var obj in objs)
            {
                if (obj.name == "Front")
                    obj.SetActive(false);
                obj.layer = 7;
            }
        }
        //inside other world
        else
        {
            door.transform.Rotate(0, -135, 0);
            foreach (var obj in objs)
            {
                if (obj.name == "Front")
                    obj.SetActive(true);
                obj.layer = 0;
            }
        }
    }

    void OnDestroy()
    {
        foreach (var obj in objs)
        {
            if (obj.name == "Front")
                obj.SetActive(false);
            obj.layer = 7;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
