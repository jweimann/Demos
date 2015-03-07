/// <summary>
///
/// File: MonoSingleton.cs
///
/// (c) Copyright Warped Imagination 2015
///
/// Description: Singleton that creates a single source for usage of a game object
///
/// Date: 6/4/2014
/// Author: David Green
///
/// </summary>

using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Mono singleton
/// This is a singleton which only stays active in the scene
/// </summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    #region Varaibles

    private static T ms_instance = null;

    #endregion

    #region Propeties

    public static bool Exists { get { return ms_instance != null; } } 
	
    public static T Instance
    {
        get
        {
            // Instance requiered for the first time, we look for it
            if( ms_instance == null )
            {
                ms_instance = GameObject.FindObjectOfType(typeof(T)) as T;
 
                // Object not found, we create a temporary one
                if( ms_instance == null )
                {
                    Debug.LogWarning("No instance of " + typeof(T).ToString() + ", a temporary one is created.");
                    ms_instance = new GameObject("Temp Instance of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();
 
                    // Problem during the creation, this should not happen
                    if( ms_instance == null )
                    {
                        Debug.LogError("Problem during the creation of " + typeof(T).ToString());
                    }
                }
                ms_instance.Init();
            }
            return ms_instance;
        }
    }

    #endregion

    #region Construction

    // If no other monobehaviour request the instance in an awake function
    // executing before this one, no need to search the object.
    private void Awake()
    {
        if( ms_instance == null )
        {
            ms_instance = this as T;
            ms_instance.Init();
        }
    }
 
	/// <summary>
    /// This function is called when the instance is used the first time
    /// Put all the initializations you need here, as you would do in Awake.
	/// </summary>
    protected abstract void Init();
 
	protected virtual void OnDestroy()
	{
		ms_instance = null;	
	}
	
    // Make sure the instance isn't referenced anymore when the user quit, just in case.
    private void OnApplicationQuit()
    {
        ms_instance = null;
    }

    #endregion
}
