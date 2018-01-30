using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballons : MonoBehaviour {
    public int life =100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetDownALife(int damage)
    {
        life = life - damage;
        if(life <=0 )
        {
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<Animator>());
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
