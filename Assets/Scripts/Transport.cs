using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class transport : MonoBehaviour
{
    public GameObject[] objs;

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
                obj.layer = 7;
            }
        }
        //inside other world
        else
        {
            foreach (var obj in objs)
            {
                obj.layer = 0;
            }
        }
    }

    void OnDestroy()
    {
        foreach (var obj in objs)
        {
            obj.layer = 7;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
