using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMyFigure{
    
    Vector3 MyMove(Vector3 myVector);

    void MouseOriginPos(Vector3 origin);
}
