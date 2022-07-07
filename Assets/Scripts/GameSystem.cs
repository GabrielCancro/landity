using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameSystem instance = null;
    GameObject selectedLight;
    GameObject buildPanel;
    GameObject currentSelected;
    GameObject mainCamera;
    public GameObject prefabBuild;

    public static GameSystem get_instance()
    {
        return instance;
    }

    private void Start()
    {
        if (!instance) instance = this;
        selectedLight = GameObject.Find("SelectedLight");
        buildPanel = GameObject.Find("BuildPanel");
        buildPanel.SetActive(false);
        mainCamera = GameObject.Find("MainCamera");
    }

    public void onClickElement(GameObject GO)
    {
        if (GO.tag == "Build" || GO.tag == "Place")
        {
            Debug.Log(GO);
            currentSelected = GO;            
            var pos = currentSelected.transform.position;
            selectedLight.transform.position = new Vector3(pos.x, .1f, pos.z);
            mainCamera.GetComponent<scCamera>().destine = new Vector3(pos.x, 5f, pos.z-5f);
            buildPanel.SetActive(false);
            if (GO.tag == "Place") buildPanel.SetActive(true);            
        }
    }

    public void onClickUI(string name = "none")
    {
        Debug.Log(name);
        if (name == "Camp" || name == "Barrack" || name == "Tower")
        {
            var BUILD = Instantiate(prefabBuild, currentSelected.transform.position, Quaternion.identity);
            BUILD.GetComponent<scBuild>().setType(name);
            Destroy(currentSelected);
            onClickElement(BUILD);
        }
    }
}
