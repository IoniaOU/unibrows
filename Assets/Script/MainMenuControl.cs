using UnityEngine;
using System.Collections;

public class MainMenuControl : MonoBehaviour
{

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void goToLevelSelection()
    {
        Application.LoadLevel(1);
    }
}
