using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scBuild : MonoBehaviour
{

    public GameObject prefabCamp = null;
    public GameObject prefabBarrack = null;
    public GameObject prefabTower = null;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setType(string type)
    {
        var prefab = prefabCamp;
        if (type == "Barrack") prefab = prefabBarrack;
        if (type == "Tower") prefab = prefabTower;

        Destroy(gameObject.transform.Find("Cube").gameObject);
        var BUILD = Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
        BUILD.transform.parent = gameObject.transform;
    }
}
