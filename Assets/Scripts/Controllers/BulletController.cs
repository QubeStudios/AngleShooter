using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.utils;

namespace game.controllers
{
	public class BulletController : MonoBehaviour {



		public int angle = 0;

		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
		// Set the selected angle 
		void OnMouseDown()
		{
			ProjectVars.Instance.selected_angle = angle;
			Debug.Log ("Selected :" + angle);
		}
	}
}
