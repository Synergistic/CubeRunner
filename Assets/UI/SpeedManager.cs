using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedManager : MonoBehaviour {
	
	
	public static float speed;
	
	Text text;
	
	// Use this for initialization
	void Awake () 
	{
		text = GetComponent<Text> ();
		speed = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Speed: " + speed.ToString();
	}
}
