using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.utils;

namespace game.controllers
{
	public class CannonController : MonoBehaviour {

		/* Attributes */

		public GameObject[] bullets;
		public int maxbullets;

		private Transform parent;
		private GameObject bullet;
		private bool rotating = false;


		/* Public Methods */

		// Use this for initialization
		void Start () 
		{
			parent = transform.parent.transform;
		}

		// Update is called once per frame
		void Update () 
		{
			if (rotating)
				Move ();
		}

		// Load the cannon (OnMouseClick Button)
		public void Load()
		{
			Debug.Log("Load Cannon");
			// get Selected angle from PojectsVars
			int angle = ProjectVars.Instance.selected_angle;

			//Find the selected bullet
			for (int i = 0 ; i< bullets.Length ; i++){
				if(angle == bullets[i].GetComponent<BulletController>().angle){
					bullet = bullets [i];
					// enable the movement of the cannon
					rotating = true;
					return;
				}
			}



		
		}

		public void Move()
		{
			// objective vector
			Vector3 to = new Vector3(0, 0, ProjectVars.Instance.selected_angle);

			if (Vector3.Distance(parent.eulerAngles, to) > 0.01f)
			{
				parent.eulerAngles = Vector3.Lerp (parent.rotation.eulerAngles, 
					// rotation in euler angles from parent of the main Gameobject
					to, 
					// objective vector
					Time.deltaTime*3f);	
				// Arrival speed 
			}
			else
			{
				parent.eulerAngles = to; // define a concrete position
				rotating = false; // stop the movement
				Fire (bullet); // shoot
			}
		}


		public void Fire( GameObject prefap)
		{


			//get the angle from BulletController Object
			float angle = prefap.GetComponent<BulletController>().angle * 1.0f;

			// Intantiate the selected bullet with the cannon rotation  
			Transform t_bullet = Instantiate (prefap.transform,
											this.transform.position,
											transform.rotation);

			// Calculate the direction of the shooting vector in x and y axis, multiplied by the firing rate
			Vector3 velocity = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle)*5f,
											Mathf.Sin(Mathf.Deg2Rad * angle)*5f, 0);
			//assign the velocity
			t_bullet.gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;
			Debug.Log("Fire");

		}


	}
}
