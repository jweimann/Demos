using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int Score { get; private set; }
    
    public static int HighScore { get; set; }

    [SerializeField]
    private Text _scoreText;

    void Start()
    {
        Score = 0;
    }
    public void IncrementScore()
    {
        Score++;
        _scoreText.text = Score.ToString();
        
        var oc = Camera.main.backgroundColor;
        Camera.main.backgroundColor = new Color(oc.r, oc.g, oc.b + (10f / 255f), oc.a);
    }

    void Update()
    {
        var oc = Camera.main.backgroundColor;
        Camera.main.backgroundColor = new Color(oc.r, oc.g, oc.b - (0.05f / 255f), oc.a);
    }
}
