using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameSystem.init();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject != null)
                {
                    GameSystem.onClickElement(raycastHit.transform.gameObject);
                }
                
            }
        }
        movementUpdate();
    }

    void movementUpdate()
    {
        if (Input.GetKey("w")) gameObject.transform.position += new Vector3(0, 0, +.05f);
        if (Input.GetKey("s")) gameObject.transform.position += new Vector3(0, 0, -.05f);
        if (Input.GetKey("a")) gameObject.transform.position += new Vector3(-.05f, 0, 0);
        if (Input.GetKey("d")) gameObject.transform.position += new Vector3(+.05f, 0, 0);
    }

}
