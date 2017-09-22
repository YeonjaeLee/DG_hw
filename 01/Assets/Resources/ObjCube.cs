using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCube : IObj {
    
    public Vector3 Moveobj(Vector3 curpos, Vector3 objpos)
    {
        Debug.Log("ObjCube 출력");
        Vector3 dispos;
        dispos = curpos - objpos;
        Vector3 setpos;
        if(Mathf.Abs(dispos.x) < Mathf.Abs(dispos.y))
        {
            setpos = new Vector3(curpos.x, objpos.y, curpos.z);
        }
        else
        {
            setpos = new Vector3(objpos.x, curpos.y, curpos.z);
        }
        return setpos;
    }
}
