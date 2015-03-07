using UnityEngine;
using System.Collections;

public class FishBasic : MonoBehaviour
{
	[SerializeField] // This attribute makes it show in the Inspector
    private float _flightHeight = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(Vector3.up * _flightHeight);
        }

        if (FishWentTooHighOrTooLow)
        {
            PauseGame();
        }
    }

    #region Fish Range Checking

    private const float MINIMUM_HEIGHT = -19f;
    private const float MAXIMUM_HEIGHT = 25f;
    private bool FishWentTooHighOrTooLow { get { return transform.position.y < MINIMUM_HEIGHT || transform.position.y > MAXIMUM_HEIGHT; } }

    public void PauseGame()
    {
    }

    #endregion
}