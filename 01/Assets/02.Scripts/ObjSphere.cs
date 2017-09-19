using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSphere : MonoBehaviour, IObj{

    public void Clickobj(GameObject target, bool click)
    {
        if (click == true)
        {
            target.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            target.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void Moveobj(GameObject target, Vector3 curpos, Vector3 objpos)
    {
        target.transform.position = objpos;
    }
}
