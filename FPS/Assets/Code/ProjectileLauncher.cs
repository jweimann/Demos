using UnityEngine;
using System.Collections;

public class ProjectileLauncher : MonoBehaviour {

    [SerializeField]
    private float _firePower = 1f;
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        PoolManager poolManager = GameObject.FindObjectOfType<PoolManager>();
        GameObject projectile = poolManager.GetPooledObject();
        projectile.transform.position = this.transform.position;
        projectile.SetActive(true);
        projectile.rigidbody.AddForce(this.transform.forward * _firePower);
    }
}
