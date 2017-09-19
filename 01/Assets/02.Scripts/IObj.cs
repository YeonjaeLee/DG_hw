using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObj {

    void Clickobj(GameObject target, bool click);
    void Moveobj(GameObject target, Vector3 curpos, Vector3 mousepos);
}
