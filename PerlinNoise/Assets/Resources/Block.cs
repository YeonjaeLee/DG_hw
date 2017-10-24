using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int Index;
    public static Block instance;
    private Material material;
    
    private void Awake() {
        instance = this;
        material = Resources.Load<Material>("Materials/soil");
        transform.GetComponent<Renderer>().material = material;
    }
    
    private void OnMouseUp()
    {
        if(!DragCameraMove.Drag)
        {
            Debug.Log(Index);
            GameManager.target = gameObject;
            GameManager.MovePlayer();
        }
    }
}
