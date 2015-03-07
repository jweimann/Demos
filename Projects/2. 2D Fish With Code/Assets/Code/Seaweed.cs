using UnityEngine;
using System.Collections;

public class Seaweed : MonoBehaviour {

    [SerializeField]
    public float speed = 3f;
    [SerializeField]
    private float _screenEdge = 15f;

    [SerializeField]
    private float _range = 3f; // Random Height 

	// Update is called once per frame
	void Update ()
    {
        if (GameState.Instance.ObjectsShouldStop)
            return;

        MoveForward();

        if (IsOffLeftSideOfScreen())
        {
            if (_range != 0)
            {
                MoveToRightOfScreenAtRandomHeight();
            }
            else
            {
                MoveToRightOfScreen();
            }
        }
	}

    private bool IsOffLeftSideOfScreen()
    {
        return this.transform.position.x < -_screenEdge;
    }

    private void MoveToRightOfScreenAtRandomHeight()
    {
        this.transform.position = new Vector3(
            _screenEdge, 
            Random.Range(-_range, _range), 
            this.transform.position.z);
    }

    private Vector3 MoveToRightOfScreen()
    {
        return this.transform.position = new Vector3(
            _screenEdge, 
            this.transform.position.y, 
            this.transform.position.z);
    }

    private void MoveForward()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
