using game.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    private GameObject bullet;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ProjectVars.Instance.actMove)
            MoveCannon();
        if (ProjectVars.Instance.actFire)
            Fire();
    }
    void MoveCannon()
    {
        bullet = ProjectVars.Instance.actShoot;
        Vector3 to = new Vector3(0, 0, ProjectVars.Instance.selected_angle);
        if (Vector3.Distance(this.transform.eulerAngles, to) > 0.01f)
        {
            this.transform.eulerAngles = Vector3.Lerp(this.transform.rotation.eulerAngles,
                // rotation in euler angles from parent of the main Gameobject
                to,
                // objective vector
                Time.deltaTime * 3f);
            // Arrival speed 
        }
        else
        {
            this.transform.eulerAngles = to; // define a concrete position
            ProjectVars.Instance.actMove = false; // stop the movements
        }
    }
    public void Fire()
    {
        //get the angle from BulletController Object
        float angle = bullet.GetComponent<BulletController>().angle * 1.0f;
        // Intantiate the selected bullet with the cannon rotation  
        Transform t_bullet = Instantiate(bullet.transform,
                                       new Vector3(this.transform.position.x, this.transform.position.y, -0.2f),
                                       transform.rotation);
        // Calculate the direction of the shooting vector in x and y axis, multiplied by the firing rate
        Vector3 velocity = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle) * 5f,
                                        Mathf.Sin(Mathf.Deg2Rad * angle) * 5f, 0);
        //assign the velocity
        t_bullet.gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        ProjectVars.Instance.actFire = false; // stop the movements
    }

}

