/************************************************************************************

Filename    :   OVRVolumeControl.cs
Content     :   Volume controller interface. 
				This script is used to display a popup UI dialog when the volume is changed.
				Override with a subclass and replace the OVRVolumeController prefab.
Created     :   September 24, 2014
Authors     :   Jim Dose

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/

using UnityEngine;
using System.Collections;

public class OVRVolumeControl : MonoBehaviour {
	private const float 		ShowPopupTime = 3;
	private const float			PopupOffsetY = 64.0f / 500.0f;
	private const float			PopupDepth = 1.8f;
	private const int 			MaxVolume = 15;
	private const int 			NumVolumeImages = MaxVolume + 1;
	
	private Transform			MyTransform = null;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad( gameObject );
		MyTransform = transform;
		renderer.enabled = false;
		
	}
	
	// Updates the position of the volume popup
	// Should be called by the current camera controller in LateUpdate
	public virtual void UpdatePosition ( Quaternion cameraRot, Vector3 cameraPosition )
	{
		// OVRDevice.GetTimeSinceLastVolumeChange() will return -1 if the volume listener hasn't initialized yet,
		// which sometimes takes place after a frame has run in Unity.
		double timeSinceLastVolumeChange = OVRDevice.GetTimeSinceLastVolumeChange();
		if ( ( timeSinceLastVolumeChange != -1 ) && ( timeSinceLastVolumeChange < ShowPopupTime ) )
		{
			renderer.enabled = true;
			renderer.material.mainTextureOffset = new Vector2( 0, ( float )( MaxVolume - OVRDevice.GetVolume() ) / ( float )NumVolumeImages );
			if ( MyTransform != null )
			{
				// place in front of camera
				MyTransform.rotation = cameraRot;
				MyTransform.position = cameraPosition + ( MyTransform.forward * PopupDepth ) + ( MyTransform.up * PopupOffsetY );
			}
		}
		else
		{
			renderer.enabled = false;
		}
	}
}
