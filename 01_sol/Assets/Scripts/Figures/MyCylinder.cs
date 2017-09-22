using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCylinder : IMyFigure
{
    Vector3 DeltaPos;
    Vector3 OriginPos;
    public Vector3 MyMove(Vector3 myMove)
    {
        DeltaPos = new Vector3(OriginPos.x, myMove.y, 0); 
        return DeltaPos;
    }
    public void MouseOriginPos(Vector3 Origin)
    {
        OriginPos = Origin;
    }
}