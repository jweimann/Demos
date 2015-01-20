using UnityEngine;
using System.Collections;

public class FishBasic : MonoBehaviour
{
	[SerializeField] // This makes it show in the Inspector
    private float _flightHeight = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(Vector3.up * _flightHeight);
        }

        if (transform.position.y < -19f ||
         transform.position.y > 25f)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
    }
}