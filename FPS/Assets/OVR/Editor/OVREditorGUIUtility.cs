/************************************************************************************

Filename    :   OVREditorGUIUtility.cs
Content     :   Player controller interface. 
				This script adds extended editor functionality
Created     :   January 17, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEngine;
using UnityEditor;

//-------------------------------------------------------------------------------------
// ***** OVREditorGUIUtility
//
// OVREditorGUIUtility contains a collection of GUI utilities for editor classes.
//
public static class OVREditorGUIUtility
{
	public static void Separator()
	{
		GUI.color = new Color(1, 1, 1, 0.25f);
		GUILayout.Box("", "HorizontalSlider", GUILayout.Height(16));
		GUI.color = Color.white;
	}

}

