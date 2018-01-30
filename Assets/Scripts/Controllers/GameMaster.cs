using game.utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject[] Bullets;
    public TextMesh ScoreInGame;
    public TextMesh MaxBullets;
    public GameObject UI_Pause;
    public GameObject UI_Menu;
    // Use this for initialization
    void Start () {
        ProjectVars.Instance.actShoot = Bullets[0];

    }
	
	// Update is called once per frame
	void Update () {
        ScoreInGame.text= "Score : "+ ProjectVars.Instance.score.ToString();
        MaxBullets.text = "Bullets x"+ ProjectVars.Instance.maxBullets.ToString();
    }
    public void OnPause()
    {
        UI_Pause.SetActive(true);
    }
    public void OffPause()
    {
        UI_Pause.SetActive(false);
    }
    public void OnMenu()
    {
        UI_Menu.SetActive(true);
    }
    public void OffMenu()
    {
        UI_Menu.SetActive(false);
    }
    public void OnSong()
    {
        if (this.gameObject.GetComponent<AudioSource>().mute)
            this.gameObject.GetComponent<AudioSource>().mute = false;
        else
            this.gameObject.GetComponent<AudioSource>().mute = true; 
    }
}
