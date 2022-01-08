using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ResetAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ARSession arSession = GetComponent<ARSession>();
        arSession.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
