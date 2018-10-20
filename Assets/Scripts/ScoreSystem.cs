using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreSystem : MonoBehaviour {
    public static int highScore { get; set; }
    public int currentScore { get; set; }
    public Text affichage;


	// Use this for initialization
	void Start () {
        affichage.text = "000000";
    }
	
	// Update is called once per frame
	void Update () {
        affichage.text = "Score : " + ((long) 0000000000).ToString() + currentScore.ToString();
	}
}
