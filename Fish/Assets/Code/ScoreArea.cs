using UnityEngine;
using System.Collections;

public class ScoreArea : MonoBehaviour 
{

    private bool _entered;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (_entered)
            return;

        _entered = true;

        Debug.Log("Entered Score Trigger " + other.name);

        var myScoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
        
        myScoreKeeper.IncrementScore();
    }


    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited!!! Score Trigger " + other.name);
        _entered = false;
    }
}
