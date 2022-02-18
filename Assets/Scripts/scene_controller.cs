using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using UnityEngine.Networking;

public class scene_controller : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CodeInput;
    public TMP_Text codePrompt;
    private bool wrongInput = false;
    public static Data json_data;
    public GameObject loading;

    private string input;
    private int str_len = 0;
    private string firstLetter = "";
    private string secondLetter = "";
    public static Texture2D cust_texture;

    private void Start()
    {
        MainMenu.SetActive(true);
        CodeInput.SetActive(false);
    }

    public void readStringInput(string s)
    {
        input = s;
    }

    public void SetScene()
    {
        str_len = input.Length;
        firstLetter = input.Substring(0,1);
        secondLetter = input.Substring(1,1);
        if(str_len > 2)
        {
            string thirdLetter = input.Substring(2, 1);
            string code = input.Substring(3, str_len-3);
            Debug.Log("3rd: " + thirdLetter);
            if (thirdLetter != "_")
            {
                wrongInput = true;
            }
            else
            {
                Debug.Log("validating..");
                CodeInput.SetActive(false);
                loading.SetActive(true);
                var data = checkCodeValidation((firstLetter + secondLetter), code);
                PlayerPrefs.SetInt("customised", 1);
                // loading screen
                // check code from database
                if (data != null)
                {
                    // correct code
                    // store text and image
                    PlayerPrefs.SetString("cust_text", data.text);
                    StartCoroutine(LoadImage(data.url));
                    LoadScene();
                }
                else
                {
                    CodeInput.SetActive(true);
                    loading.SetActive(false);
                    wrongInput = true;
                }

            }
        }
        //Load default cards
        else
        {
            PlayerPrefs.SetInt("customised", 0);
            LoadScene();
        }
    }

    public void LoadScene()
    {
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
    public JSONSerialize checkCodeValidation(string card_type, string product_id)
    {
        foreach(var data in json_data.json)
        {
            if (data.cardType == card_type && data.product_id == product_id)
                return data;
        }
        return null;
    }

    IEnumerator LoadImage(string ImageURL)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(ImageURL);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //fetch texture
            cust_texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
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
        Application.OpenURL("https://augmg.site/augmg/index.php");
    }

    private void Update()
    {
        if(wrongInput)
        {
            codePrompt.text = "Please Enter Your\nCard Code\n<color=red>Wrong code! Try again</color>";
        }
    }

}
