/************************************************************************************

Filename    :   OVRDebugGraph.cs
Content     :   Helper component that can be dropped onto a GameObject to assist
			:	in enabling the Android OVR debug graph
Created     :   June 27, 2014
Authors     :   Andrew Welch

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/

using UnityEngine;
using System.Runtime.InteropServices;	// required for DllImport

public class OVRDebugGraph : MonoBehaviour {

	public OVRTimeWarpUtils.DebugPerfMode		debugMode = OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_OFF;
	public OVRGamepadController.Button			toggleButton = OVRGamepadController.Button.Start;	

	[DllImport("OculusPlugin")]
	private static extern void OVR_TW_SetDebugMode( OVRTimeWarpUtils.DebugPerfMode mode, OVRTimeWarpUtils.DebugPerfValue value );
	
	/// <summary>
	/// Initialize the debug mode
	/// </summary>
	void Start () {
#if (UNITY_ANDROID && !UNITY_EDITOR)
		// Turn on/off debug graph
		OVR_TW_SetDebugMode( debugMode, OVRTimeWarpUtils.DebugPerfValue.DEBUG_VALUE_DRAW );
#endif
	}

	/// <summary>
	/// Check input and toggle the debug graph
	/// See the input mapping setup in the Unity Integration guide
	/// </summary>
	void Update() {
		// NOTE: some of the buttons defined in OVRGamepadController.Button are not available on the Android game pad controller
		if ( Input.GetButtonDown( OVRGamepadController.ButtonNames[(int)toggleButton] ) ) {

			Debug.Log( " TOGGLE GRAPH " );

			//*************************
			// toggle the debug graph .. off -> running -> paused
			//*************************
			switch( debugMode ) {
			case OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_OFF:
				debugMode = OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_RUNNING;
				break;
			case OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_RUNNING:
				debugMode = OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_FROZEN;
				break;
			case OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_FROZEN:
				debugMode = OVRTimeWarpUtils.DebugPerfMode.DEBUG_PERF_OFF;
				break;
			}
#if (UNITY_ANDROID && !UNITY_EDITOR)
			OVR_TW_SetDebugMode( debugMode, OVRTimeWarpUtils.DebugPerfValue.DEBUG_VALUE_DRAW );
#endif
		}
	}

}
