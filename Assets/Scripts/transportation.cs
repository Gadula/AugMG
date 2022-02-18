using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transportation : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject door;
    public Material[] skybox;
    public GameObject[] themeWorlds;
    public TMPro.TMP_Text greetings;
    private int themeNum = 1;
    private string currentTheme = "Space";
    public GameObject astronaut;

    public GameObject face;
    public SpriteRenderer faceTex;

    // Start is called before the first frame update
    void Start()
    {
        // check if to show default card
        if(PlayerPrefs.GetInt("customised") == 0)
        {
            // show default
            if (currentTheme == "Space")
            {
                greetings.text = "You are my world <3";
                face.SetActive(false);
            }
            else if (currentTheme == "Christmas")
            {
                greetings.text = "Merry Christmas!";
            }
        }
        else
        {
            // show customized
            //set customized text
            greetings.text = PlayerPrefs.GetString("cust_text");
            //set customized image
            faceTex = face.GetComponent<SpriteRenderer>();
            faceTex.sprite = Sprite.Create(scene_controller.cust_texture, new Rect(0.0f, 0.0f, scene_controller.cust_texture.width, scene_controller.cust_texture.height), new Vector2(0.5f, 0.5f), 100.0f);

        }

        themeNum = PlayerPrefs.GetInt("theme");
        switch (themeNum)
        {
            case 1:
                currentTheme = "Christmas";
                break;
            case 2:
                currentTheme = "Space";
                break;
        }
        foreach (GameObject theme in themeWorlds)
        {
            if(currentTheme == theme.name)
            {
                theme.SetActive(true);
            }
            else
            {
                theme.SetActive(false);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.name != "AR Camera")
            return;

        //outside of other world
        if (other.transform.position.z <= 1.78)
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
