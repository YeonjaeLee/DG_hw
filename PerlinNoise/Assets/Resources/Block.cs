using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private Material material;

    private void Awake() {
        material = Resources.Load<Material>("Materials/soil");
        transform.GetComponent<Renderer>().material = material;
    }
}
