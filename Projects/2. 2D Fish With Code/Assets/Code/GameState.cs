using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoSingleton<GameState>
{
    [SerializeField]
    private Text _pausedText;

    public bool ObjectsShouldStop { get { return IsPlayerDead || GameHasStarted == false; } }
    public bool IsPlayerDead { get; private set; }
    public bool GameHasStarted { get; set; }

    public void StartGame()
    {
        IsPlayerDead = false;
        GameHasStarted = true;

        _pausedText.gameObject.SetActive(false);
        GameObject.FindObjectOfType<Fish>().ResumeGame();
    }

    public void KillPlayer()
    {
        IsPlayerDead = true;

        GameObject.FindObjectOfType<Fish>().PauseGame();
        GameObject.FindObjectOfType<ScoreKeeper>().PauseGame();
        _pausedText.gameObject.SetActive(false);
    }
   

    protected override void Init() { }
}
