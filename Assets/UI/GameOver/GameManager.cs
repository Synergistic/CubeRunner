using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	private Animator scoreAnim;
	private Animator gameOverAnim;
    private ScoreSaver scoreSaver;
    private InputField userNameInput;
    private Text enteredText;
    private Button submitButton;
    private Text buttonText;

	// Use this for initialization
	void Awake () 
	{
		scoreAnim = GameObject.Find ("ScoreText").GetComponent<Animator> ();
		gameOverAnim = GameObject.Find ("GameOverText").GetComponent<Animator> ();
        scoreSaver = gameObject.GetComponent<ScoreSaver>();
        userNameInput = GameObject.Find("NameInput").GetComponent<InputField>();
        enteredText = GameObject.Find("NameText").GetComponent<Text>();
        submitButton = GameObject.Find("SubmitButton").GetComponent<Button>();
        buttonText = GameObject.Find("SubmitText").GetComponent<Text>();

    }
	
	public void GameOver ()
	{
		scoreAnim.SetTrigger ("GameOver");
		gameOverAnim.SetTrigger ("GameOver");
        userNameInput.interactable = true;
        enteredText.text = "Enter name for leaderboards.";
        enteredText.color = Color.black;
        buttonText.color = Color.black;
        submitButton.interactable = true;

	}

    public void SubmitScore()
    {
        if (enteredText.text.Length < 11 && !enteredText.text.Contains(" "))
        {
            submitButton.interactable = false;
            scoreSaver.SaveScore(enteredText.text, (double)ScoreManager.score);
            enteredText.text = "Submitted!";
            Invoke("LoadMenu", 2);
        }
        else
        {
            enteredText.text = "Name has max length of 10, no spaces.";
        }

    }

	void LoadMenu()
	{
		Application.LoadLevel("MainMenu");
	}

}
