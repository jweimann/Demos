/************************************************************************************

Filename    :   GameUtils.cs
Content     :   Helpful game-related utility functions.
Created     :   March 5, 2014
Authors     :   Jonathan E. Wright

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/

using UnityEngine;
using System.Collections.Generic;

public class OVRGameUtils
{
	static public GameObject FindChildNoWarning( GameObject obj, string name )
	{
		if ( obj.name == name )
		{
			return obj;
		}
		foreach ( Transform child in obj.transform )
		{
			GameObject found = FindChildNoWarning( child.gameObject, name );
			if ( found )
			{
				return found;
			}
		}		
		return null;
	}
	
	static public GameObject FindChild( GameObject obj, string name )
	{
		GameObject go = FindChildNoWarning( obj, name );
		if ( go == null )
		{
			DebugUtils.Print( "child " + name + " was not found!" );
		}
		return go;
	}
};