using game.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int angle = 0;
    public int damage = 100;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > 7 || this.transform.position.x > 7.5 || this.transform.position.y < -7.5)
        {
            ProjectVars.Instance.actButton_Fire = true;//Activar Boton de disparo
            Destroy(this.gameObject);
        }
    }
    void OnMouseDown()
    {
        ProjectVars.Instance.selected_angle = angle;
        ProjectVars.Instance.actShoot = this.gameObject;
        ProjectVars.Instance.actMove = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "balloon")
        {
            collision.gameObject.GetComponent<Ballons>().GetDownALife(damage);
            //Destroy(collision.gameObject);
            ProjectVars.Instance.actButton_Fire = true;//Activar Boton de disparo
            ProjectVars.Instance.score += 100;
            DestroyObject(this.gameObject);
        }
    }
}