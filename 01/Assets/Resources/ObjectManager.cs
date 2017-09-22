using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    public static ObjectManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ObjectManager();
            }
            return instance;
        }
    }

    public Vector3 Obpos;

    public enum OB_TYPE
    {
        SPHERE,
        CUBE,
        CYLLINDER
    }

    private void Awake()
    {
        instance = this;
    }

    public void Createobj()
    {
        int rand = 0;
        rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = Obpos;
                sphere.AddComponent<Obj>();
                sphere.GetComponent<Obj>().SetObj(csObj(rand));
                break;
            case 1:
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = Obpos;
                cube.AddComponent<Obj>();
                cube.GetComponent<Obj>().SetObj(csObj(rand));
                break;
            case 2:
                GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cylinder.transform.position = Obpos;
                cylinder.AddComponent<Obj>();
                cylinder.GetComponent<Obj>().SetObj(csObj(rand));
                break;
        }
    }

    private IObj csObj(int rand)
    {
        IObj csOb = null;
        switch(rand)
        {
            case 0:
                csOb = new ObjSphere();
                break;
            case 1:
                csOb = new ObjCube();
                break;
            case 2:
                csOb = new ObjCylinder();
                break;
        }

        return csOb;
    }

    public void Clickobj(GameObject target, bool click)
    {
        if (click == true)
        {
            target.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            target.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
