using UnityEngine;
using System.Collections;

public class WormControl : MonoBehaviour
{
	public bool isSelected = false;
	public GameObject[] effectedObjects;
    public AudioClip upSfx;
    public AudioClip downSfx;
    private float delay;
    private bool delayControl = false;
    private float randomWinDelay = 0;
	void Start ()
	{
        randomWinDelay = Random.Range(0.1f, 0.5f);
        delay = Random.Range(0.1f, 1.0f);
    }

	void Update ()
	{
        if (delayControl)
        {
            delay -= Time.deltaTime;
            if (delay < 0)
            {
                ChangeOtherSelection();
                delayControl = false;
                delay = Random.Range(0.1f, 0.5f);
            }
        }
        if (GameLogic.currentState == (int)GameLogic.states.WIN)
        {
            randomWinDelay -= Time.deltaTime;
            if (randomWinDelay < 0)
            {
                gameObject.GetComponent<Animator>().Play("win");
            }
        }
	}

	void OnMouseDown ()
	{
		if(GameLogic.currentState == (int)GameLogic.states.PLAY)
		{
            GameLogic.tap++;
			ChangeSelection(true);
		}
	}
    public void EffectOthers()
    {
        foreach (GameObject obj in effectedObjects)
        {
            obj.GetComponent<WormControl>().ChangeSelection(false);
        }
    }
    public void ChangeOtherSelection()
    {
        if (!isSelected)
        {
            gameObject.GetComponent<Animator>().Play("down");
            gameObject.GetComponent<AudioSource>().clip = downSfx;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("up");
            gameObject.GetComponent<AudioSource>().clip = upSfx;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
	public void ChangeSelection(bool isThis)
	{
        if (isThis)
        {
            if (isSelected)
            {
                gameObject.GetComponent<Animator>().Play("down");
                gameObject.GetComponent<AudioSource>().clip = downSfx;
                gameObject.GetComponent<AudioSource>().Play();
                isSelected = !isSelected;
            }
            else
            {
                gameObject.GetComponent<Animator>().Play("up");
                gameObject.GetComponent<AudioSource>().clip = upSfx;
                gameObject.GetComponent<AudioSource>().Play();
                isSelected = !isSelected;
            }
            EffectOthers();
        }
        else
        {
            if (isSelected)
            {
                isSelected = !isSelected;
            }
            else
            {
                isSelected = !isSelected;
            }
            delayControl = true;
        }
	}
}
