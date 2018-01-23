using game.controllers;
using game.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public CannonController A;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ProjectVars.Instance.ButtonFire)
        {
            ProjectVars.Instance.ButtonFire = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    public void OnMouseDown()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        A.Fire();
    }
}
