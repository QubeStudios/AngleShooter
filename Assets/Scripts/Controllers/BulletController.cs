using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.utils;

namespace game.controllers
{
	public class BulletController : MonoBehaviour {
		public int angle = 0;
        public CannonController A;
        // Use this for initialization
        void Start () 
		{
			
		}
		// Update is called once per frame
		void Update () 
		{
            if (this.transform.position.y > 7 || this.transform.position.x>7.5 || this.transform.position.y<-7.5)
            {
                ProjectVars.Instance.maxbullets--;
                ProjectVars.Instance.ButtonFire = true;//Activar Boton de disparo
                Destroy(this.gameObject);
            }
                
        }
		// Set the selected angle 
		void OnMouseDown()
		{
			ProjectVars.Instance.selected_angle = angle;
            ProjectVars.Instance.shoot = this.gameObject;
            A.Load();
            Debug.Log ("Selected :" + angle);
		}
        private void OnTriggerEnter2D(Collider2D collision)
        {

            ProjectVars.Instance.puntaje += 100;
            ProjectVars.Instance.maxGloves--;
            Destroy(collision.gameObject);
            ProjectVars.Instance.ButtonFire = true;//Activar Boton de disparo
        }
    }
}
