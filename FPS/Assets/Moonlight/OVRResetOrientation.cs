/************************************************************************************

Filename    :   OVRResetOrientation.cs
Content     :   Helper component that can be dropped onto a GameObject to assist
			:	in resetting device orientation
Created     :   June 27, 2014
Authors     :   Andrew Welch

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/

using UnityEngine;

public class OVRResetOrientation : MonoBehaviour {
	
	public OVRGamepadController.Button			resetButton = OVRGamepadController.Button.Y;	
	
	/// <summary>
	/// Check input and reset orientation if necessary
	/// See the input mapping setup in the Unity Integration guide
	/// </summary>
	void Update() {
		// NOTE: some of the buttons defined in OVRGamepadController.Button are not available on the Android game pad controller
		if ( Input.GetButtonDown( OVRGamepadController.ButtonNames[(int)resetButton] ) ) {
			//*************************
			// reset orientation
			//*************************
			OVRDevice.ResetOrientation();
		}
	}

}
