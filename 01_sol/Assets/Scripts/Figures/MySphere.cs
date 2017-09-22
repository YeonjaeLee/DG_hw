using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySphere : IMyFigure {

    Vector3 DeltaPos;
    Vector3 OriginPos;
    public Vector3 MyMove(Vector3 myMove)
    {
        DeltaPos = myMove;
        return DeltaPos;
    }
    public void MouseOriginPos(Vector3 Origin)
    {
        OriginPos = Origin;
    }
}
