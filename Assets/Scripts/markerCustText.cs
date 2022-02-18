using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markerCustText : MonoBehaviour
{
    public TMPro.TMP_Text greetings;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("customised") == 1)
        {
            // show customized
            //set customized text
            greetings.text = PlayerPrefs.GetString("cust_text");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
