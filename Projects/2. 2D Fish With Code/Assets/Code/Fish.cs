using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    #region Inspector Fields

    [SerializeField]
    private float _flightHeight = 500f;
    [SerializeField]
    private float _tiltSpeed = 10f;
    
    [SerializeField]
    private ScoreKeeper _scorekeeper;

    #endregion

    #region Private Properties
    private bool FishIsTooHighOrTooLow { get { return transform.position.y < -19f || transform.position.y > 25f; } }
    #endregion

    void Start()
    {
        rigidbody2D.isKinematic = true; // Stops the fish from moving due to gravity & collisions
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            HandleFire1Pressed();
        }

        if (FishIsTooHighOrTooLow)
        {
            PauseGame();
        }

        TiltFishBasedOnVelocity();
    }

    private void HandleFire1Pressed()
    {
        if (GameState.Instance.IsPlayerDead)
        {
            GameState.Instance.GameHasStarted = false;
            Application.LoadLevel(0);
        }
        else if (GameState.Instance.GameHasStarted == false)
        {
            GameState.Instance.StartGame();
        }
        else
        {
            AddUpwardForceToFish();
        }
    }

    private void AddUpwardForceToFish()
    {
        rigidbody2D.velocity = Vector2.zero; // Stops the fish
        rigidbody2D.AddForce(Vector3.up * _flightHeight);
    }

    private static void RestartGameIfPlayerPressesFire1()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Application.LoadLevel(0);
        }
    }

    private void TiltFishBasedOnVelocity()
    {
        float pct = rigidbody2D.velocity.y / 3f;

        float angle = Mathf.Lerp(-75f, 45f, pct);

        var targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _tiltSpeed);
    }

    
    public void ResumeGame()
    {
        rigidbody2D.isKinematic = false; // Make the fish use physics again.
    }

    public void PauseGame()
    {
        rigidbody2D.isKinematic = true;
    }
}