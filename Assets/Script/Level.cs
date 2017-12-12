using System.Collections;

public class Level
{
	public int timeLimit;
	public int moveLimit;
	public Worm[,] levelMap;
    public Level(int _timeLimit, int _moveLimit, Worm[,] _levelMap)
    {
        timeLimit = _timeLimit;
        moveLimit = _moveLimit;
        levelMap = _levelMap;
    }
}
