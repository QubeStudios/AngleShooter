using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {


	public GameObject[] bullets;

	private Transform parent;
	private GameObject bullet;
	public int maxbullets;

	// Use this for initialization
	void Start () {
		parent = transform.parent.transform;
	}
	private bool rotating = false;
	// Update is called once per frame
	void Update () {
		if (rotating)
		{
			Vector3 to = new Vector3(0, 0, BulletController.selected_angle);

			if (Vector3.Distance(parent.eulerAngles, to) > 0.01f)
			{
				
				parent.eulerAngles = Vector3.Lerp (parent.rotation.eulerAngles, to, Time.deltaTime*3f);


			}
			else
			{
				parent.eulerAngles = to;
				rotating = false;
				Fire (bullet);
			}

		}
	}

	public void Load(){
		int angle = BulletController.selected_angle;

		rotating = true;
		
		for (int i = 0 ; i< bullets.Length ; i++){
			if(angle == bullets[i].GetComponent<BulletController>().angle){
				bullet = bullets [i];
				return;
			}
			
		}
			

		
	}

	private int bullet_index = 0;
	public void Fire( GameObject prefap){
		

		float angle = prefap.GetComponent<BulletController>().angle * 1.0f;
		Transform t_bullet = Instantiate (prefap.transform, this.transform.position, transform.rotation);

		Vector3 velocity = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle)*5f, Mathf.Sin(Mathf.Deg2Rad * angle)*5f, 0);
		t_bullet.gameObject.GetComponent<Rigidbody2D> ().velocity = velocity;




	}


}
