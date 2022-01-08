using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class exit_manager : MonoBehaviour
{
    
    
    public void backHome()
    {
        SceneManager.LoadScene("AR_Menu");
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                Application.Quit();
            else
            {
                SceneManager.LoadScene(0);
            }
                
        }
    }

}
