using System.Collections;

public class Worm
{
    public enum WormType {RED,YELLOW,BLUE,GREEN};
    public int type;
    public bool isSelected;
    public Worm(int _type,bool _isSelected)
    {
        type = _type;
        isSelected = _isSelected;
    }
}
