/************************************************************************************

Filename    :   OVRPresetManager.cs
Content     :   Save or load a collection of variables
Created     :   March 7, 2013
Authors     :   Peter Giokaris

Copyright   :   Copyright 2014 Oculus VR, LLC. All Rights reserved.


************************************************************************************/
using UnityEngine;
using System.Collections.Generic;

//-------------------------------------------------------------------------------------
// ***** OVRPresetManager
//
/// <summary>
/// OVRPresetManager is a helper class to allow for a set of variables to be saved and
/// recalled using the Unity PlayerPrefs class. 
///
/// OVRPresetManager is currently being used by the OVRMainMenu component.
///
/// </summary>
public class OVRPresetManager
{	
	static string PresetName = "";
	
	/// <summary>
	/// Sets the current preset.
	/// </summary>
	/// <returns><c>true</c>, if current preset was set, <c>false</c> otherwise.</returns>
	/// <param name="presetName">Preset name.</param>
	public bool SetCurrentPreset(string presetName)
	{
		PresetName = presetName;
		return true;
	}
	
	/// <summary>
	/// Sets the property int.
	/// </summary>
	/// <returns><c>true</c>, if property int was set, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool SetPropertyInt(string name, ref int v)
	{
		string key = PresetName + name;
		PlayerPrefs.SetInt (key, v);
		return true;
	}
	
	/// <summary>
	/// Gets the property int.
	/// </summary>
	/// <returns><c>true</c>, if property int was gotten, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool GetPropertyInt(string name, ref int v)
	{
		string key = PresetName + name;		
		if(PlayerPrefs.HasKey(key) == false)
			return false;
		
		v = PlayerPrefs.GetInt (key);
		return true;
	}
	
	/// <summary>
	/// Sets the property float.
	/// </summary>
	/// <returns><c>true</c>, if property float was set, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool SetPropertyFloat(string name, ref float v)
	{
		string key = PresetName + name;
		PlayerPrefs.SetFloat (key, v);
		return true;
	}
	
	/// <summary>
	/// Gets the property float.
	/// </summary>
	/// <returns><c>true</c>, if property float was gotten, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool GetPropertyFloat(string name, ref float v)
	{
		string key = PresetName + name;		
		if(PlayerPrefs.HasKey(key) == false)
			return false;
		
		v = PlayerPrefs.GetFloat (key);
		return true;
	}
	
	/// <summary>
	/// Sets the property string.
	/// </summary>
	/// <returns><c>true</c>, if property string was set, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool SetPropertyString(string name, ref string v)
	{
		string key = PresetName + name;
		PlayerPrefs.SetString (key, v);
		return true;
	}
	
	/// <summary>
	/// Gets the property string.
	/// </summary>
	/// <returns><c>true</c>, if property string was gotten, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	/// <param name="v">V.</param>
	public bool GetPropertyString(string name, ref string v)
	{
		string key = PresetName + name;		
		if(PlayerPrefs.HasKey(key) == false)
			return false;
		
		v = PlayerPrefs.GetString(key);
		return true;
	}

	/// <summary>
	/// Deletes the property.
	/// </summary>
	/// <returns><c>true</c>, if property was deleted, <c>false</c> otherwise.</returns>
	/// <param name="name">Name.</param>
	public bool DeleteProperty(string name)
	{
		string key = PresetName + name;
		PlayerPrefs.DeleteKey(key);	
		return true;
	}
	
	/// <summary>
	/// Saves all.
	/// </summary>
	/// <returns><c>true</c>, if all was saved, <c>false</c> otherwise.</returns>
	public bool SaveAll()
	{
		PlayerPrefs.Save();
		return true;
	}
	
	/// <summary>
	/// Deletes all.
	/// </summary>
	/// <returns><c>true</c>, if all was deleted, <c>false</c> otherwise.</returns>
	public bool DeleteAll()
	{
		PlayerPrefs.DeleteAll();
		return true;
	}
}
