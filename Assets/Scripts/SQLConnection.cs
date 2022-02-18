using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SQLConnection : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(getCodeInfo());
    }

    // Update is called once per frame
    IEnumerator getCodeInfo()
    {
        // read from api created that retireved from products table
        using (UnityWebRequest www = UnityWebRequest.Get("https://augmgconnection.herokuapp.com/getCodeInfo"))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                scene_controller.json_data = JsonUtility.FromJson<Data>(www.downloadHandler.text);
                //show results as text
                Debug.Log(scene_controller.json_data.json.Count);
            }
        }
    }
}
