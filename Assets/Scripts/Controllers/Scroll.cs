using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
    public float velocidad = 0f;
    public Material material;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	     material.mainTextureOffset = new Vector2(Time.time * velocidad, 0);
	}
}
