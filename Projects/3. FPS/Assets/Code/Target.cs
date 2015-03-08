using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        GameObject.Destroy(this.gameObject);
    }
}
