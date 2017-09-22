using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour {
    public IObj iObj;
    public ObjectManager.OB_TYPE ObjectType;

    public void SetObj(IObj obj)
    {
        iObj = obj;
    }
    public void SetMove(Vector3 curpos, Vector3 objpos)
    {
        this.gameObject.transform.position = iObj.Moveobj(curpos, objpos);
    }
}
