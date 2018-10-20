using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Data;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject fond1;
    [SerializeField]
    private GameObject fond2;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject zone;

    private List<LevelDescription> levelDescription;
    [SerializeField]
    private TextAsset levelsDatabase;

    Level mylevel;

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

    private void Awake()
    {
        /* 
        Instantiate(player);
        Instantiate(fond1);
        Instantiate(fond2);
        Instantiate(canvas);
        Instantiate(zone);*/

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
    void Update()
    {
        if (isPlaying)
        {
            CheckVictory();
        }
    }

    void CheckVictory()
    {

        if (myCorgi.currentHealth == 0)
        {
            if (myScore.currentScore > ScoreSystem.highScore)
            {
                ScoreSystem.highScore = myScore.currentScore;
            }
            myCanvas.Dead(Time.time, mylevel.nbWave, myScore.currentScore);
            isPlaying = false;
        }

        if (!end)
        {
            return;
        }

        wavesObjectif.text = "Wave : " + mylevel.nbWave + "/" + mylevel.nbWaveMax;
        Debug.Log(mylevel.nbWave);

        if (mylevel.Win)
        {
            if (myScore.currentScore > ScoreSystem.highScore)
            {
                ScoreSystem.highScore = myScore.currentScore;
            }
            myCanvas.Victory(Time.time, mylevel.nbWave, myScore.currentScore);
            isPlaying = false;
        }


    }

    void UpdateTest()
    {
        mySpawn.ChangeSpawn(rateEasy, nbEnnemisEasy);
    }

    void UpdateNiveau()
    { 
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

        if (MenuManager.typeJeu == 1 || MenuManager.typeJeu == 0)
        {
            end = true;

            mylevel = GetComponent<Level>();
            Debug.Assert(mylevel != null);

            levelDescription = XmlHelpers.DeserializeDatabaseFromXML<LevelDescription>(this.levelsDatabase);
            if (levelDescription == null)
            {
                Debug.LogError("XMl n'est pas chargé");
            }
            LoadLevelScript();
        }
        else
        {
            LoadLevelRandom();
        }

    }

    void LoadLevelScript()
    {
        mylevel.StartLoad(levelDescription);
    }

    void LoadLevelRandom()
    {
        mySpawn.BeginRandom();
    }
}
