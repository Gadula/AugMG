using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadCode : MonoBehaviour
{
    public string ImageName;
    public string BaseURL;
    public GameObject loading;
    public RawImage Image;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LoadImage(BaseURL));
    }

    IEnumerable LoadImage(string ImageURL)
    {
        WWW www = new WWW(ImageURL);
        loading.SetActive(true);
        yield return www;

        if (!File.Exists(Application.persistentDataPath + ImageName))
        {
            //if internet available
            if (www.error == null)
            {
                //When image is downloaded
                loading.SetActive(false);
                Texture2D texture = www.texture;
                Image.texture = texture;
                byte[] dataByte = texture.EncodeToPNG();
                File.WriteAllBytes(Application.persistentDataPath + ImageName + "png", dataByte);
                Debug.Log("Image saved");
            }
            //if internet not available
            else
            {
                Debug.Log("have error");
            }
        }
        else if (!File.Exists(Application.persistentDataPath + ImageName))
        {
            loading.SetActive(false);
            byte[] UploadByte = File.ReadAllBytes(Application.persistentDataPath + ImageName);
            Texture2D texture = new Texture2D(10, 10);
            texture.LoadImage(UploadByte);
            Image.texture = texture;
            Debug.Log("Image loaded");
        }
        }
        
    }
