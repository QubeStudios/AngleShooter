using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace game.utils{
	

    public class ProjectVars : Singleton<ProjectVars>
    {
        public int puntaje = 0;
	    public int selected_angle = 0;
        public GameObject shoot;
        public bool ButtonFire = false;//Se utiliza para activar o desactiva la funcionalidad del boton mientras se genera el disparo
        public int maxbullets = 0;
        public int maxGloves;
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
