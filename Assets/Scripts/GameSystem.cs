using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameObject selectedLight;
    static GameObject buildPanel;
    static GameObject currentSelected;
    static GameObject mainCamera;
    static bool initialized = false;

    public static void init()
    {
        if (initialized == false)
        {
            initialized = true;
            selectedLight = GameObject.Find("SelectedLight");
            buildPanel = GameObject.Find("BuildPanel");
            buildPanel.SetActive(false);
            mainCamera = GameObject.Find("MainCamera");
        }        
    }

    public static void onClickElement(GameObject GO)
    {
        if (GO.tag == "Build" || GO.tag == "Place")
        {
            currentSelected = GO;            
            var pos = currentSelected.transform.position;
            selectedLight.transform.position = new Vector3(pos.x, .1f, pos.z);
            mainCamera.transform.position = new Vector3(pos.x, 5f, pos.z-5f);
            buildPanel.SetActive(false);
            if (GO.tag == "Place") buildPanel.SetActive(true);            
        }
    }

    public static void onClickUI(string name = "none")
    {
        Debug.Log(name);
    }
}
