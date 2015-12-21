using UnityEngine;
using System.Collections;

public class SceneTransitioner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TransitionTo(string LevelName)
    {
        Application.UnloadLevel(Application.loadedLevel);
        if (string.IsNullOrEmpty(LevelName))
            Application.LoadLevel("DEV");
        else
            Application.LoadLevel(LevelName);
    }
}
