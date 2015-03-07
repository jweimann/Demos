using UnityEngine;
using System.Collections;

public class SeaweedPart : MonoBehaviour 
{

    void OnTriggerEnter2D(Collider2D other)
    {
        GameState.Instance.KillPlayer();
    }

}
