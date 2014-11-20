using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        Application.LoadLevel("MainGame");
    }

    public void ShowLeaderboard()
    {
        Application.LoadLevel("Leaderboard");
    }
}
