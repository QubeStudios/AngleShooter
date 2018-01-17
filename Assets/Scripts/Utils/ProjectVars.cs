using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace game.utils{
	

public class ProjectVars : Singleton<ProjectVars>
{
	/// <summary>
	
	/// </summary>
	
	public int selected_angle = 0;



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
