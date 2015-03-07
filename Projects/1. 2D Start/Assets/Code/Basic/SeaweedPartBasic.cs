using UnityEngine;
using System.Collections;

public class SeaweedPartBasic : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
		Application.LoadLevel(0);
    }

}
