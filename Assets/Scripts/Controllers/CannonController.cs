using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.utils;
using UnityEngine.UI;

namespace game.controllers
{
	public class CannonController : MonoBehaviour {

		/* Attributes */

		public GameObject[] bullets;
		public int maxbullets;
        public int maxGloves;

        public TextMesh Score;
		private Transform parent;
		private GameObject bullet;
		private bool rotating = false;
        [Header("UI Final")]
        public GameObject MenuFinal;
        public GameObject Win;
        public GameObject Lose;
        public TextMesh ScoreFinal;
        /* Public Methods */

        // Use this for initialization
        void Start () 
		{
			parent = transform.parent.transform;
            ProjectVars.Instance.maxbullets = maxbullets;
            ProjectVars.Instance.maxGloves = maxGloves;

        }

		// Update is called once per frame
		void Update () 
		{
            if (ProjectVars.Instance.maxbullets == 0 || ProjectVars.Instance.maxGloves == 0)
            {
                UI_Final_Active();
            }
            else
            {
                Score.text = "SCORE : " + ProjectVars.Instance.puntaje.ToString();
                if (rotating)
                    Move();
            }
		}

		// Load the cannon (OnMouseClick Button)
		public void Load()
		{
			Debug.Log("Load Cannon");
            //Se obtiene la figura actual seleccionada
            bullet = ProjectVars.Instance.shoot;
            rotating = true;
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
				rotating = false; // stop the movements
			}
		}


		public void Fire(  )
		{
            //get the angle from BulletController Object
            float angle = bullet.GetComponent<BulletController>().angle * 1.0f;

            // Intantiate the selected bullet with the cannon rotation  
           
 
             Transform t_bullet = Instantiate (bullet.transform,
											new Vector3(this.transform.position.x, this.transform.position.y,0f),
											transform.rotation);

            
			// Calculate the direction of the shooting vector in x and y axis, multiplied by the firing rate
			Vector3 velocity = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle)*5f,
											Mathf.Sin(Mathf.Deg2Rad * angle)*5f, 0);
			//assign the velocity
			t_bullet.gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;
            
            Debug.Log("Fire");

		}
        private void UI_Final_Active()
        {
            if (ProjectVars.Instance.maxGloves==0)
            {
                ScoreFinal.text = "SCORE : " + ProjectVars.Instance.puntaje.ToString();
                Win.SetActive(true);
                MenuFinal.SetActive(true);
            }
            else
            {
                ScoreFinal.text = "SCORE : " + ProjectVars.Instance.puntaje.ToString();
                Lose.SetActive(true);
                MenuFinal.SetActive(true);
                
            }
        }

    }
}
