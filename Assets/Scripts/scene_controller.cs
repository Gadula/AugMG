using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class scene_controller : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CodeInput;
    public TMP_Text codePrompt;
    private bool wrongInput = false;
    private int theme;

    private string input;

    private void Start()
    {
        MainMenu.SetActive(true);
        CodeInput.SetActive(false);
    }

    public void readStringInput(string s)
    {
        input = s;
    }

    //public void LoadScene(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //}

    public void LoadScene()
    {
        string firstLetter = input.Substring(0,1);
        string secondLetter = input.Substring(1,1);
        if (firstLetter == "A" || firstLetter == "a")
        {
            //Load Marker-based AR
            //if code found
            if (secondLetter == "1")
            {
                SceneManager.LoadScene("AR_Marker_1");
            }
            else if (secondLetter == "2")
            {
                SceneManager.LoadScene("AR_Marker_2");
            }
            else if (secondLetter == "3")
            {
                SceneManager.LoadScene("AR_Marker_3");
            }
            else
                wrongInput = true;
        }
        else if (firstLetter == "B" || firstLetter == "b")
        {
            //Load Portal AR
            //if code found
            if (secondLetter == "1" || secondLetter == "2")
            {
                SceneManager.LoadScene("AR_PortalCard");
                PlayerPrefs.SetInt("theme", int.Parse(secondLetter));
            }
            else
                wrongInput = true;
        }
        else
        {
            wrongInput = true;
        }
        
    }

    public void switchMenu()
    {
        if (MainMenu.activeSelf)
        {
            MainMenu.SetActive(false);
            CodeInput.SetActive(true);
        }
        else
        {
            MainMenu.SetActive(true);
            CodeInput.SetActive(false);
        }


    }

    public void RedirectWeb()
    {
        Application.OpenURL("https://helloaugmg.wixsite.com/home");
    }

    private void Update()
    {
        if(wrongInput)
        {
            codePrompt.text = "Please Enter Your\nCard Code\n<color=red>Wrong code! Try again</color>";
        }
    }

}
