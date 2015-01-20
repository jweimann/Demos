/************************************************************************************

Filename    :   OVRWaitCursor.cs
Content     :   Helper component that can be dropped onto a GameObject to auto
			:	rotate a loading or 'wait' cursor
Created     :   June 27, 2014
Authors     :   Andrew Welch

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/

using UnityEngine;

public class OVRWaitCursor : MonoBehaviour {

	public Vector3			rotateSpeeds = new Vector3( 0.0f, 0.0f, -60.0f );
	private Transform 		thisTransform = null;

	/// <summary>
	/// Initialization
	/// </summary>
	void Awake () {
		thisTransform = transform;
	}
	
	/// <summary>
	/// Auto rotates the attached cursor
	/// </summary>
	void Update() {
		thisTransform.Rotate( rotateSpeeds * Time.smoothDeltaTime );
	}
	
}