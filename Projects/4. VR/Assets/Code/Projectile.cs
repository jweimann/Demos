using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    [SerializeField]
    private float _deactivateAfterSeconds = 3f;

    private float _secondsSinceActivation;

	void OnEnable() 
    {
        _secondsSinceActivation = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        _secondsSinceActivation += Time.deltaTime;
        if (_secondsSinceActivation >= _deactivateAfterSeconds)
        {
            // Same functionality as the Generic FindObjectOfType
            // Just different syntax.  Requires casting.
            PoolManager poolManager = 
                (PoolManager)GameObject.FindObjectOfType(typeof(PoolManager));

            poolManager.DeactivateObjectAndAddToPool(this.gameObject);
        }
	}
}
