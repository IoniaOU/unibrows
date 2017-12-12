using UnityEngine;
using System.Collections;

public class LevelSelectMenuControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenLevel(int l)
    {
        LevelCreator.currentLevel = l - 1;
        Application.LoadLevel(2);
    }
}
