using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCylinder : IObj{

    public Vector3 Moveobj(Vector3 curpos, Vector3 objpos)
    {
        Debug.Log("ObjCylinder 출력");
        Vector3 setpos;
        setpos = new Vector3(curpos.x, objpos.y, curpos.z);

        return setpos;
    }
}
