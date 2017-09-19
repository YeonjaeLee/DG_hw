using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCube : MonoBehaviour, IObj {
    
    public void Clickobj(GameObject target, bool click)
    {
        if(click == true)
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
        Vector3 dispos;
        dispos = curpos - objpos;
        if(Mathf.Abs(dispos.x) < Mathf.Abs(dispos.y))
        {
            target.transform.position = new Vector3(curpos.x, objpos.y, curpos.z);
        }
        else
        {
            target.transform.position = new Vector3(objpos.x, curpos.y, curpos.z);
        }
        Debug.Log("Cube Move: " + objpos);
    }
}
