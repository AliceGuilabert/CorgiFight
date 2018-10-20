using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NiveauController : MenuManager {

    Spawn mySpawn;
    public Text wavesObjectif;
    BaseAvatar myCorgi;
    CanvasController myCanvas;
    ScoreSystem myScore;

    [SerializeField]
    private int nbWavesEasy;
    [SerializeField]
    private int nbWavesMedium;
    [SerializeField]
    private int nbWavesHard;

    [SerializeField]
    private int rateEasy;
    [SerializeField]
    private int nbEnnemisEasy;
    [SerializeField]
    private int rateMedium;
    [SerializeField]
    private int nbEnnemisMedium;
    [SerializeField]
    private int rateHard;
    [SerializeField]
    private int nbEnnemisHard;

    private bool end;

   private bool isPlaying;

    // Use this for initialization
    void Start () {
        mySpawn = GetComponent<Spawn>();
        myCorgi = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseAvatar>();
        myCanvas = GameObject.FindGameObjectWithTag("UI").GetComponent<CanvasController>();
        myScore = GetComponent<ScoreSystem>();
        wavesObjectif.text = "";
        UpdateNiveau();
       // UpdateTest();
        isPlaying = true;
	}

	// Update is called once per frame
	void Update () {
        if(isPlaying)
        {
            CheckVictory();
        }    
    }

    void CheckVictory()
    {
        
        if(myCorgi.currentHealth == 0)
        {
            if(myScore.currentScore > ScoreSystem.highScore)
            {
                ScoreSystem.highScore = myScore.currentScore;
            }
            myCanvas.Dead(Time.time, mySpawn.nbWaves, myScore.currentScore);
            isPlaying = false;
        }
        
        if (!end)
        {
            return;
        }
        
        if (MenuManager.difficulty == 1)
        {
            wavesObjectif.text ="Wave : " + mySpawn.nbWaves + "/" + nbWavesEasy;
            if (mySpawn.nbWaves > nbWavesEasy)
            {
                if (myScore.currentScore > ScoreSystem.highScore)
                {
                    ScoreSystem.highScore = myScore.currentScore;
                }
                myCanvas.Victory(Time.time, mySpawn.nbWaves, myScore.currentScore);
                isPlaying = false;
            }
        } 
        else if (MenuManager.difficulty == 2)
        {
            wavesObjectif.text = mySpawn.nbWaves + "/" + nbWavesMedium;
            if (mySpawn.nbWaves > nbWavesMedium)
            {
                Debug.Log("Gagnéééé");
            }
        }
        else
        {
            wavesObjectif.text = mySpawn.nbWaves + "/" + nbWavesHard;
            if (mySpawn.nbWaves > nbWavesHard)
            {
                Debug.Log("Gagnéééé");
            }
        }
        

    }

    void UpdateTest()
    {
        mySpawn.ChangeSpawn(rateEasy, nbEnnemisEasy);
    }

    void UpdateNiveau()
    {
        if (MenuManager.typeJeu == 1)
        {
            end = true;
        } 

        if (MenuManager.difficulty == 1)
        {
            mySpawn.ChangeSpawn(rateEasy, nbEnnemisEasy);

        }
        else if (MenuManager.difficulty == 2)
        {
            mySpawn.ChangeSpawn(rateMedium, nbEnnemisMedium);
        }
        else
        {
            mySpawn.ChangeSpawn(rateHard, nbEnnemisHard);
        }

    }

}
