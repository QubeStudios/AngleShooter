using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if((Input.GetKey(KeyCode.LeftArrow)))
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x - 0.1f, this.gameObject.transform.position.y);
        }
        if ((Input.GetKey(KeyCode.RightArrow)))
        {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 0.1f, this.gameObject.transform.position.y);
        }
    }
}
