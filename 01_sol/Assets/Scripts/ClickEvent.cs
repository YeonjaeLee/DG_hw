using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEvent : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        ObjectManager.Instance.MoveFigure(objPosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        Debug.Log("Clicked");

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 300)){
            if(hit.collider.gameObject.tag == "Figure")
            {
                Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
                Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                ObjectManager.Instance.ClickObject(hit.collider.gameObject, objPosition);
            }
        }
        else
        {
            ObjectManager.Instance.CreateNewFigure();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UnClicked");
        ObjectManager.Instance.UnClickObject();
    }
}
