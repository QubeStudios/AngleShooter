using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace game.utils{
	

    public class ProjectVars : Singleton<ProjectVars>
    {
        [Header("BulletControllers")]
        public GameObject actShoot;//Almacenara la bala selecionada
        public int selected_angle;//Angulo seleccionado

        public bool actMove = false;
        public bool actFire = false;
        public bool actButton_Fire = false;
        
        public int maxBullets = 2;
        public int score = 0;
      
        public static ProjectVars Instance
	    {
		    get
		    {
			    return ((ProjectVars)mInstance);
		    }
		    set
		    {
			    mInstance = value;
		    }
	    }
	    protected ProjectVars() { }
    }
}
