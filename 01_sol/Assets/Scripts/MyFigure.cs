using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFigure : MonoBehaviour {

    public IMyFigure myFigure;
    public ObjectManager.FIGURE_TYPE CurrentType;

    public void SetFigure(IMyFigure myfigure)
    {
        myFigure = myfigure;
    }
    public void SetMove(Vector3 MouseDeltaPos)
    {
        this.gameObject.transform.position = myFigure.MyMove(MouseDeltaPos);
    }
    public void SetOrigin(Vector3 MousePos)
    {
        myFigure.MouseOriginPos(MousePos);
    }
}
