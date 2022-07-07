using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCamera : MonoBehaviour
{

    public Vector3 destine = new Vector3();
    float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {
        destine = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        clickRaycast();
        moveKeyboard();
        moveToDestine();
    }

    void clickRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null && raycastHit.transform.gameObject != null)
                {
                    GameSystem.get_instance().onClickElement(raycastHit.transform.gameObject);
                }

            }
        }
    }
    void moveKeyboard()
    {
        var mov = new Vector3();
        if (Input.GetKey("w")) mov.z += 1.5f;
        if (Input.GetKey("s")) mov.z -= 1.5f;
        if (Input.GetKey("a")) mov.x -= 1.5f;
        if (Input.GetKey("d")) mov.x += 1.5f;
        if (mov.magnitude != 0) destine = gameObject.transform.position + mov;
    }

    void moveToDestine()
    {
        if (Vector3.Distance(destine, gameObject.transform.position) > speed)
        {
            var mov = (destine - gameObject.transform.position) * .8f;
            gameObject.transform.position += mov * speed;
        }
    }


}
