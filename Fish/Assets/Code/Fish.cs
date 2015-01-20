using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{
    [SerializeField]
    private float flightHeight = 500f;
    [SerializeField]
    private float tiltSpeed = 10f;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private ScoreKeeper _scorekeeper;

    private bool _restarted = true;

    void Start()
    {
        GameState.IsPaused = true;
        rigidbody2D.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.IsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ResumeGame();
            }
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StopFishThenAddUpwardForce();
        }

        if (FishIsTooHighOrTooLow())
        {
            PauseGame();
        }

        TiltFishBasedOnVelocity();
    }

    private void StopFishThenAddUpwardForce()
    {
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(Vector3.up * flightHeight);
    }

    private void TiltFishBasedOnVelocity()
    {
        float pct = rigidbody2D.velocity.y / 3f;

        float angle = Mathf.Lerp(-75f, 45f, pct);

        var targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed);
    }

    private bool FishIsTooHighOrTooLow()
    {
        return transform.position.y < -19f ||
                 transform.position.y > 25f;
    }

    private void ResumeGame()
    {
        GameState.IsPaused = false;
        rigidbody2D.isKinematic = false;
        _restarted = false;
        _gameOverText.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        _gameOverText.gameObject.SetActive(true);
        if (_scorekeeper.Score > ScoreKeeper.HighScore)
        {
            ScoreKeeper.HighScore = _scorekeeper.Score;
            _gameOverText.text = "You got a high score of " + ScoreKeeper.HighScore;
        }
        else
        {
            _gameOverText.text = "You scored " + _scorekeeper.Score + " your high score was " + ScoreKeeper.HighScore;
        }
        GameState.IsPaused = true;
        rigidbody2D.isKinematic = true;
    }
}