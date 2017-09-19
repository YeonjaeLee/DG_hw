using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseRespones : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    Vector3 mousepos;
    private GameObject target;

    public void OnPointerDown(PointerEventData eventData)
    {
        target = GetClickedObject();

        ObjectManager.instance.Obpos = Camera.main.ScreenToWorldPoint(
            new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z)
            );

        if (target == null)
        {
            ObjectManager.instance.Createobj();
        }
        else
        {
            ObjectManager.instance.Checkobj(target);
            ObjectManager.instance.Clickobj(target, true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousepos = Camera.main.ScreenToWorldPoint(
            new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            -Camera.main.transform.position.z)
            );

        if (target != null)
        {
            ObjectManager.instance.Moveobj(target, mousepos);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(target != null)
            ObjectManager.instance.Clickobj(target, false);
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

    bool isRed;
}
