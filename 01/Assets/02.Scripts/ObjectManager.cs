using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    public static ObjectManager instance;
    public Vector3 Obpos;
    string chobj;

    private void Awake()
    {
        instance = this;
    }

    public void Createobj()
    {
        int rand = 0;
        rand = Random.Range(0, 3);
        
        switch(rand)
        {
            case 0:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Obpos;
                break;
            case 1:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Obpos;
                break;
            case 2:
                GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cylinder.transform.position = Obpos;
                break;
        }
    }

    public void Clickobj(GameObject target, bool click)
    {
        switch(chobj)
        {
            case "Cube":
                IObj iobj1 = new ObjCube();
                iobj1.Clickobj(target, click);
                break;
            case "Cylinder":
                IObj iobj2 = new ObjCylinder();
                iobj2.Clickobj(target, click);
                break;
            case "Sphere":
                IObj iobj3 = new ObjSphere();
                iobj3.Clickobj(target, click);
                break;
        }
        
    }

    public void Moveobj(GameObject target, Vector3 mousepos)
    {
        switch (chobj)
        {
            case "Cube":
                IObj iobj1 = new ObjCube();
                iobj1.Moveobj(target, Obpos, mousepos);
                break;
            case "Cylinder":
                IObj iobj2 = new ObjCylinder();
                iobj2.Moveobj(target, Obpos, mousepos);
                break;
            case "Sphere":
                IObj iobj3 = new ObjSphere();
                iobj3.Moveobj(target, Obpos, mousepos);
                break;
        }
    }

    public void Checkobj(GameObject target)
    {
        chobj = target.transform.tag;
    }
}
