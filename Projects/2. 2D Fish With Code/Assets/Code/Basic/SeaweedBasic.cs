using UnityEngine;
using System.Collections;

public class SeaweedBasic : MonoBehaviour
{
    [SerializeField] // This attribute makes it show in the Inspector
    private float _speed = 2.5f;
    [SerializeField]
    private float _screenEdge = 15f;

    private bool IsOffLeftSideOfScreen { get { return this.transform.position.x < -_screenEdge; } }

	// Update is called once per frame
    void Update()
    {
        MoveForward();

        if (IsOffLeftSideOfScreen)
        {
            ResetToRightOfScreen();
        }
    }

    private void MoveForward()
    {
        this.transform.Translate(Vector3.left * Time.deltaTime * _speed);
    }
    
    private void ResetToRightOfScreen()
    {
        this.transform.position = new Vector3(_screenEdge, this.transform.position.y, 0f);
    }
}
