/************************************************************************************

Filename    :   OVRImageEffectBase.cs
Content     :   Full screen image effect. 
				This script is a base class for Unity image effects
				component
Created     :   February 21, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("")]

//-------------------------------------------------------------------------------------
// ***** OVRImageEffectBase
//
// OVRImageEffectBase is a base class to be used for full screen image effects.
// It will keep the effect from being enabled if Unity does not support it.
//
public class OVRImageEffectBase : MonoBehaviour
{
	/// Provides a shader property that is set in code
	/// and a material instantiated from the shader
	//// -- UnityAndroid
	[HideInInspector]
	[System.NonSerialized]
	//// -- UnityAndroid
	public Material material;

	protected void Start ()
	{
		// Disable if we don't support image effects
		if (!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}
	}
}
