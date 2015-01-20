using UnityEngine;
using System.Collections;

public class SeaweedBasic : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _screenEdge = 15f;

	// Update is called once per frame
    void Update()
    {
        MoveForward();

        if (IsOffLeftSideOfScreen())
        {
            MoveToRightOfScreen();
        }
    }

    private void MoveForward()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }

	bool IsOffLeftSideOfScreen ()
	{
		return this.transform.position.x < -_screenEdge;
	}
    
    private void MoveToRightOfScreen()
    {
        this.transform.position = new Vector3(_screenEdge, this.transform.position.y, 0f);
    }
}
