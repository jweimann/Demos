using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fish : MonoBehaviour
{

    public float flightHeight = 500f;
    public float tiltSpeed = 10f;

    [SerializeField]
    private Text _gameover;

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
        if (_restarted)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ResumeGame();
            }
            return;
        }
        else if (GameState.IsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Application.LoadLevel(0);
            }
            return;
        }
        

        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(Vector3.up * flightHeight);
        }

        if (FishIsTooHighOrTooLow())
        {
            PauseGame();
        }

        TiltFishBasedOnVelocity();
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
        _gameover.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        _gameover.gameObject.SetActive(true);
        if (_scorekeeper.Score > ScoreKeeper.HighScore)
        {
            ScoreKeeper.HighScore = _scorekeeper.Score;
            _gameover.text = "You got a high score of " + ScoreKeeper.HighScore;
        }
        else
        {
            _gameover.text = "You scored " + _scorekeeper.Score + " your high score was " + ScoreKeeper.HighScore;
        }
        GameState.IsPaused = true;
        rigidbody2D.isKinematic = true;
    }
}