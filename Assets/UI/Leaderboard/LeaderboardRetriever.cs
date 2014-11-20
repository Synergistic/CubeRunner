using System;
using com.shephertz.app42.paas.sdk.csharp.game;
using com.shephertz.app42.paas.sdk.csharp;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace AssemblyCSharp
{
    public class LeaderboardRetriever : App42CallBack
	{
		private string result = "";
		private List<string> names = new List<string>();
        private List<string> scores = new List<string>();
        private List<DateTime> dates = new List<DateTime>();

		public void OnSuccess (object obj)
		{
			if (obj is Game) {
				Game gameObj = (Game)obj;
				result = gameObj.ToString ();
				if (gameObj.GetScoreList () != null) {
					IList<Game.Score> scoreList = gameObj.GetScoreList ();
					for (int i = 0; i < scoreList.Count; i++) {
						names.Add(scoreList [i].GetUserName ());
                        dates.Add(scoreList[i].GetCreatedOn());
                        scores.Add(scoreList [i].GetValue ().ToString());
					}
				}
			} else {
				IList<Game> game = (IList<Game>)obj;
				result = game.ToString ();
				for (int j = 0; j < game.Count; j++) {
					Debug.Log ("GameName is   : " + game [j].GetName ());
					Debug.Log ("Description is  : " + game [j].GetDesription ());
				}
			}
            DisplayTopScores();
					
		}
		
		public void OnException (Exception e)
		{
			result = e.ToString ();
			Debug.Log ("EXCEPTION : " + e);
            DisplayNone();
	
		}

        void DisplayNone()
        {
            Text text = GameObject.Find("1st").GetComponent<Text>();
            text.color = Color.black;
            text.text = "No one here yet!";
        }
		
		public string getResult ()
		{
			return result;
		}

        void DisplayTopScores()
        {
            Text[] positions = GameObject.Find("TopPlayers").GetComponentsInChildren<Text>();
            int max = Math.Min(positions.Length, names.Count);
            if (positions.Length > 0 && names.Count > 0)
            {
                for (int i = 0; i < max; i++)
                {
                    positions[i].text = names[i] + "        " + scores[i] + "        " + dates[i].Date.ToString("MMM d");
                    positions[i].color = Color.black;
                }
            }
        }
		
	}
      
}

