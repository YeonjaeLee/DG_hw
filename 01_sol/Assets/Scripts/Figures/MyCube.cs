using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCube : IMyFigure {

    Vector3 DeltaPos;
    Vector3 OriginPos;

    float xPos, yPos;
    public Vector3 MyMove(Vector3 myMove)
    {
        xPos = OriginPos.x - myMove.x;
        yPos = OriginPos.y - myMove.y;
        if(Math.Abs(xPos) > Math.Abs(yPos))
        {
            DeltaPos = new Vector3(myMove.x, OriginPos.y, 0);
        }
        else
        {
            DeltaPos = new Vector3(OriginPos.x, myMove.y, 0);
        }
        return DeltaPos;
    }
    public void MouseOriginPos(Vector3 Origin)
    {
        OriginPos = Origin;
    }
}
