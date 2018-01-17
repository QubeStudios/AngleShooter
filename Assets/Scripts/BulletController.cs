using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {


	public static int selected_angle = 0;
	public int angle = 0;
	public int count = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown(){
		selected_angle = angle;
		Debug.Log ("Selected :" + angle);
	}
}
