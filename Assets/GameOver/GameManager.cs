using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private Animator scoreAnim;
	private Animator gameOverAnim;

	// Use this for initialization
	void Awake () 
	{
		scoreAnim = GameObject.Find ("ScoreText").GetComponent<Animator> ();
		gameOverAnim = GameObject.Find ("GameOverText").GetComponent<Animator> ();
	}
	
	public void GameOver ()
	{
		Invoke ("ReloadLevel", 5);
		scoreAnim.SetTrigger ("GameOver");
		gameOverAnim.SetTrigger ("GameOver");
	}

	void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

}
