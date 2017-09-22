using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    private static ObjectManager instance;
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

    private void Awake()
    {
        instance = this;
    }

    public GameObject[] MyFigures;
    public GameObject MyFigure1;

    private GameObject currnetObject = null;
    
    public enum FIGURE_TYPE
    {
        SPHERE,
        CYLLINDER,
        CUBE
    }

    private IMyFigure SelectMyFigure(int rand)
    {
        IMyFigure tempFigure = null;
        switch (rand)
        {
            case (int)FIGURE_TYPE.SPHERE:
                tempFigure = new MySphere();
                break;
            case (int)FIGURE_TYPE.CYLLINDER:
                tempFigure = new MyCylinder();
                break;
            case (int)FIGURE_TYPE.CUBE:
                tempFigure = new MyCube();
                break;
        }

        return tempFigure;
    }

    public void CreateNewFigure()
    {
        int rand = Random.Range(0, 3);
        GameObject go;
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        go = Instantiate(MyFigures[rand], objPosition, Quaternion.Euler(0, 0, 0));
        //go = MyFigures[rand];
        //Debug.Log("Fuck");
        
        go.AddComponent<MyFigure>();
        go.GetComponent<MyFigure>().SetFigure(SelectMyFigure(rand));
    }
    
    public void ClickObject(GameObject clicked, Vector3 mousePos)
    {
        currnetObject = clicked;
        currnetObject.GetComponent<MyFigure>().SetOrigin(mousePos);
        currnetObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void UnClickObject()
    {
        if(currnetObject != null)
        {
            currnetObject.GetComponent<Renderer>().material.color = Color.white;
            currnetObject = null;
        }
    }

    public void MoveFigure(Vector3 mouseDeltaPos)
    {
        if (currnetObject != null)
        {
            currnetObject.GetComponent<MyFigure>().SetMove(mouseDeltaPos);
        }
    }
}
