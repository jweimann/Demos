using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    private static float BlueToAddOnIncrement { get { return (10f / 255f); } }
    private static float BlueToRemovePerFrame { get { return (0.05f / 255f); } }

    public int Score { get; set; }
    public static int HighScore { get; set; }
    

    void Start()
    {
        Score = 0;
    }

    public void IncrementScore()
    {
        Score++;
        _scoreText.text = Score.ToString();
        
        var originalColor = Camera.main.backgroundColor;
        Camera.main.backgroundColor = new Color(
            originalColor.r,
            originalColor.g,
            originalColor.b + BlueToAddOnIncrement, 
            originalColor.a);
    }

    
    void Update()
    {
        var originalColor = Camera.main.backgroundColor;
        Camera.main.backgroundColor = new Color(
            originalColor.r,
            originalColor.g,
            originalColor.b - BlueToRemovePerFrame,
            originalColor.a);
    }

    public void PauseGame()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            _scoreText.text = "You got a high score of " + HighScore;
        }
        else
        {
            _scoreText.text = "You scored " + Score + " your high score was " + HighScore;
        }
    }
}
