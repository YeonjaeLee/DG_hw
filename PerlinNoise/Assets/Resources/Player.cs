using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    private void Awake()
    {
        transform.GetComponent<Renderer>().material.color = Color.red;
    }

    private void Update ()
    {
		
	}

    public void PlayerMove()
    {
        transform.position = new Vector3(GameManager.target.transform.position.x, GameManager.target.transform.localScale.y + 1, GameManager.target.transform.position.z);
    }
}
