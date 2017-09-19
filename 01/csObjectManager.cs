using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCube
{
    private GameObject _target;
    private Vector3 _Point;

    public csCube(GameObject target, Vector3 mouspos)
    {
        _target = target;
        _Point = mouspos;
    }

    public void Move()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Mouse X")) < Mathf.Abs(Input.GetAxisRaw("Mouse Y")))
        {
            _target.transform.position = new Vector3(_target.transform.position.x, _Point.y, _target.transform.position.z);
        }
        else
        {
            _target.transform.position = new Vector3(_Point.x, _target.transform.position.y, _target.transform.position.z);
        }
    }
}

public class csCylinder
{
    private GameObject _target;
    private Vector3 _Point;

    public csCylinder(GameObject target, Vector3 mouspos)
    {
        _target = target;
        _Point = mouspos;
    }

    public void Move()
    {
        _target.transform.position = new Vector3(_target.transform.position.x, _Point.y, _target.transform.position.z);
    }
}

public class csSphere
{
    private GameObject _target;
    private Vector3 _Point;

    public csSphere(GameObject target, Vector3 mouspos)
    {
        _target = target;
        _Point = mouspos;
    }

    public void Move()
    {
        _target.transform.position = _Point;
    }
}

public class GenericContainer<T>
{
    private T _value;

    public void SetValue(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }
}

public class csObjectManager : MonoBehaviour
{

    private Vector3 mousePos;

    public GameObject Sphere;
    public GameObject Cube;
    public GameObject Cylinder;

    private GameObject target;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();
        }

        // 클릭시 오브젝트 있으면 실행
        if (target != null)
        {
            MeshRenderer mr = target.GetComponent<MeshRenderer>();
            if (Input.GetMouseButtonDown(0))
                mr.material.color = Color.red;
            if (Input.GetMouseButton(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(
                new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                -Camera.main.transform.position.z)
                );
                if (target.transform.tag == "Cube")
                {
                    GenericContainer<csCube> gContain = new GenericContainer<csCube>();
                    gContain.SetValue(new csCube(target, mousePos));
                    gContain.GetValue().Move();
                }
                else if (target.transform.tag == "Cylinder")
                {
                    GenericContainer<csCylinder> gContain = new GenericContainer<csCylinder>();
                    gContain.SetValue(new csCylinder(target, mousePos));
                    gContain.GetValue().Move();
                }
                else if (target.transform.tag == "Sphere")
                {
                    GenericContainer<csSphere> gContain = new GenericContainer<csSphere>();
                    gContain.SetValue(new csSphere(target, mousePos));
                    gContain.GetValue().Move();
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                mr.material.color = Color.white;
                return;
            }
        }

        // 클릭시 오브젝트 없으면 생성
        if (Input.GetMouseButtonUp(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(
            new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z)
            );
            print(mousePos);

            Createobj();
        }
    }

    void Createobj()
    {
        int rand = 0;
        rand = Random.Range(0, 3);

        if (rand == 0)
        {
            GameObject obj = Instantiate(Sphere) as GameObject;
            obj.transform.position = mousePos;
        }
        else if (rand == 1)
        {
            GameObject obj = Instantiate(Cube) as GameObject;
            obj.transform.position = mousePos;
        }
        else if (rand == 2)
        {
            GameObject obj = Instantiate(Cylinder) as GameObject;
            obj.transform.position = mousePos;
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
