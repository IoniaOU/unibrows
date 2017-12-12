using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour
{
	public enum states{PLAY, NOTPLAY,WIN};
	public static int currentState;
	public static int tap = 0;
	public int time;
    public Text levelBoard;
	public Text tapBoard;
	public Text timeBoard;
	public Text winBoard;
	public Button restartButton;
	public RawImage gameoverBG;
    public GameObject _levelCreator;
    private float WinWindowDelay = 0.6f;
	private float _time = 1;
    void Awake()
    {
    }
	void Start ()
	{
        
        time = 0;
		GameLogic.currentState = (int)states.PLAY;
		tapBoard.text = "tap: "+GameLogic.tap+"/"+_levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].moveLimit;
		timeBoard.text = "time: "+time + "/" + _levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].timeLimit;
        levelBoard.text = "Level "+(LevelCreator.currentLevel + 1);
	}

	void Update ()
	{
        tapBoard.text = "tap: " + GameLogic.tap + "/" + _levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].moveLimit;
        if (tap > _levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].moveLimit)
        {
            tapBoard.color = Color.red;
        }
        if (GameLogic.currentState == (int)states.PLAY)
		{
			_time -= Time.deltaTime;
			if(_time<0)
			{
				time++;
                timeBoard.text = "time: " + time + "/" + _levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].timeLimit;
                _time = 1;
			}
			if(time> _levelCreator.GetComponent<LevelCreator>().Levels[LevelCreator.currentLevel].timeLimit)
			{
				timeBoard.color = Color.red;
			}
		}
		if(currentState == (int)states.WIN)
		{
            WinWindowDelay -= Time.deltaTime;
            if (WinWindowDelay < 0)
            {
                gameoverBG.gameObject.SetActive(true);
                winBoard.gameObject.SetActive(true);
            }
		}
	}
	public void GameOver()
	{
		restartButton.gameObject.SetActive(true);
		gameoverBG.gameObject.SetActive(true);
		GameLogic.currentState = (int)states.NOTPLAY;
	}
	public void RestartGame()
	{
        Application.LoadLevel(Application.loadedLevel);
		GameLogic.tap = 0;
	}
    public void NextLevel()
    {
        GameLogic.tap = 0;
        LevelCreator.currentLevel++;
        Application.LoadLevel(Application.loadedLevel);
    }
	public static void Win()
	{
		currentState = (int)states.WIN;
	}
}
