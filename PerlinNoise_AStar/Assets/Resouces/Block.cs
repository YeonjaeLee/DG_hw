using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int Index;
    public static Block instance;
    private Material material;
    
    private void Awake() {
        instance = this;
        transform.GetComponent<Renderer>().material.color = Color.gray;
    }
    
    private void OnMouseUp()
    {
        if(!DragCameraMove.Drag)
        {
            Grid.target = gameObject;
            Grid.MovePlayer();
        }
    }
}
