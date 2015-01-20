/************************************************************************************

Filename    :   OVRBuild.cs
Content     :   Rift editor interface. 
				This script adds the ability to build demo from within Unity and from
				command line
Created     :   February 14, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEngine;
using UnityEditor;

//-------------------------------------------------------------------------------------
// ***** OculusBuild
//
// OculusBuild adds menu functionality for a user to build the currently selected scene, 
// and to also build and run the standalone build. These menu items can be found under the
// Oculus/Build menu from the main Unity Editor menu bar.
//

class OculusBuild
{
#if UNITY_ANDROID
    // Build the Android APK and place into main project folder
    [MenuItem("Oculus/Build/Android APK")]
    static void PerformBuildAndroidAPK()
    {
        if (Application.isEditor)
        {
            string[] scenes = { EditorApplication.currentScene };
            BuildPipeline.BuildPlayer(scenes, "OculusUnityDemoScene.apk", BuildTarget.Android, BuildOptions.None);
        }
    }
#endif
}

//-------------------------------------------------------------------------------------
// ***** OculusBuildDemo
//
// OculusBuild allows for command line building of the Oculus main demo (Tuscany).
//
class OculusBuildDemo
{
	static void PerformBuildStandaloneWindows ()
	{
		string[] scenes = { "Assets/Tuscany/Scenes/VRDemo_Tuscany.unity" };
		BuildPipeline.BuildPlayer(scenes, "Win_OculusUnityDemoScene.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
    }
	
	static void PerformBuildStandaloneMac ()
	{
		string[] scenes = { "Assets/Tuscany/Scenes/VRDemo_Tuscany.unity" };
		BuildPipeline.BuildPlayer(scenes, "Mac_OculusUnityDemoScene.app", BuildTarget.StandaloneOSXIntel, BuildOptions.None);
    }
	
	static void PerformBuildStandaloneLinux ()
	{
		string[] scenes = { "Assets/Tuscany/Scenes/VRDemo_Tuscany.unity" };
		BuildPipeline.BuildPlayer(scenes, "Linux_OculusUnityDemoScene", BuildTarget.StandaloneLinux, BuildOptions.None);
    }
	
	static void PerformBuildStandaloneLinux64 ()
	{
		string[] scenes = { "Assets/Tuscany/Scenes/VRDemo_Tuscany.unity" };
		BuildPipeline.BuildPlayer(scenes, "Linux_OculusUnityDemoScene", BuildTarget.StandaloneLinux64, BuildOptions.None);
    }
}

//-------------------------------------------------------------------------------------
// ***** OculusBuildApp
//
// OculusBuildApp allows us to build other Oculus apps from the command line. 
//
partial class OculusBuildApp
{
    static void SetAndroidTarget()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
        }
    }
}