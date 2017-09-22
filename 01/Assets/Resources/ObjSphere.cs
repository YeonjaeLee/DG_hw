using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSphere : IObj{

    public Vector3 Moveobj(Vector3 curpos, Vector3 objpos)
    {
        Debug.Log("ObjSphere 출력");
        Vector3 setpos;

        setpos = objpos;

        return setpos;
    }
}
