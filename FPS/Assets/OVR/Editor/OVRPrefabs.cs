/************************************************************************************

Filename    :   OVRPrefabs.cs
Content     :   Prefab creation editor interface. 
				This script adds the ability to add OVR prefabs into the scene.
Created     :   February 19, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEditor;

//-------------------------------------------------------------------------------------
// ***** OVRPrefabs
//
// OculusPrefabs adds menu items under the Oculus main menu. It allows for quick creation
// of the main Oculus prefabs without having to open the Prefab folder and dragging/dropping
// into the scene.
class OVRPrefabs
{
	static void CreateOVRCameraController ()
	{
		Object ovrcam = AssetDatabase.LoadAssetAtPath ("Assets/OVR/Prefabs/OVRCameraController.prefab", typeof(UnityEngine.Object));
		PrefabUtility.InstantiatePrefab(ovrcam);
    }	
	
	static void CreateOVRPlayerController ()
	{
		Object ovrcam = AssetDatabase.LoadAssetAtPath ("Assets/OVR/Prefabs/OVRPlayerController.prefab", typeof(UnityEngine.Object));
		PrefabUtility.InstantiatePrefab(ovrcam);
    }	
}