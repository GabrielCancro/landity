using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    static GameObject selectedLight;
     static GameObject currentSelected;

    public static void init()
    {
        if (selectedLight) return;
        selectedLight = GameObject.Find("SelectedLight");
    }
    public static void onClickElemnt(GameObject GO)
    {
        init();
        if (GO.tag == "Build" || GO.tag == "Place")
        {
            currentSelected = GO;
            Debug.Log(currentSelected.tag);
            Debug.Log(selectedLight);
            var pos = currentSelected.transform.position;
            selectedLight.transform.position = new Vector3(pos.x,.1f,pos.z);
        }
        
    }
}
