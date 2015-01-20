/************************************************************************************

Filename    :   OVRDeviceEditor.cs
Content     :   Rift editor interface. 
				This script adds editor functionality to the OVRRift class
Created     :   February 14, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(OVRDevice))]

//-------------------------------------------------------------------------------------
// ***** OVRDeviceEditor
//
// OVRDeviceEditor adds extra functionality into the inspector for the currently selected
// OVRRift component.
//
public class OVRDeviceEditor : Editor
{
	// target component
	private OVRDevice m_Component;

	// OnEnable
	void OnEnable()
	{
		m_Component = (OVRDevice)target;
	}

	// OnDestroy
	void OnDestroy()
	{
	}
	
	// OnInspectorGUI
	public override void OnInspectorGUI()
	{
		GUI.color = Color.white;
		{
			m_Component.PredictionTime     = EditorGUILayout.Slider("Prediction Time", 		 m_Component.PredictionTime,	0, 0.1f);
			m_Component.ResetTrackerOnLoad = EditorGUILayout.Toggle("Reset Tracker On Load",  m_Component.ResetTrackerOnLoad);			
		}

		if (GUI.changed)
		{
			EditorUtility.SetDirty(target);
		}
	}		
}

