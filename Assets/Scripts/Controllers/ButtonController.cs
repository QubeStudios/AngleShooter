using game.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public int accion;
    public GameMaster Gamemaster;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(ProjectVars.Instance.actButton_Fire)
        {
            ProjectVars.Instance.actButton_Fire = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        } 
    }
    public void OnMouseDown()
    {
        switch (accion)
        {
            case 1://Activar Disparo
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                ProjectVars.Instance.maxBullets--;
                ProjectVars.Instance.actFire = true;
                break;
            case 2://Activar Pause
                Gamemaster.OnPause();
                break;
            case 3://Activar Sonido
                Gamemaster.OnSong();
                if (this.gameObject.GetComponent<SpriteRenderer>().color == new Color(0, 0, 0))
                    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                else
                    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                break;
            case 4://Desactivar Pause
                Gamemaster.OffPause();
                break;
            case 5://Activar Menu
                Gamemaster.OffPause();
                Gamemaster.OnMenu();
                break;
        }
    }
}
