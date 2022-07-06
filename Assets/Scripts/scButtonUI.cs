using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scButtonUI : MonoBehaviour
{
    public void onClicMe()
    {
        GameSystem.onClickUI(gameObject.name);
    }
}
