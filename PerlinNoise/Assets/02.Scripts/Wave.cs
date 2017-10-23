using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    private float scale = 1;        // 낮을 수록 들쑥 날쑥
    private float heightScale = 1;  // 높이

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float Move_y = heightScale = Mathf.PerlinNoise(Time.time + (transform.position.x * scale), Time.time + (transform.position.z * scale));

        this.transform.position = new Vector3(transform.position.x, Move_y, transform.position.z);
		
	}
}
