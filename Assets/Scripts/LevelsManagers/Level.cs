using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class Level : MonoBehaviour {

    private float timeStart;
    private float timeCurrentLevel;
    public int nbWave { get; set; }
    public int nbWaveMax { get; set; }

    private int numCurrentLevel;
    Spawn mySpawn;

    private List<LevelDescription> myLevelList;

    public bool Win { get; set; }


    // Use this for initialization
    void Start () {
        mySpawn = GetComponent<Spawn>();
        numCurrentLevel = 0;
        Win = false;
	}

    public void StartLoad(List<LevelDescription> levelList)
    {
        myLevelList = levelList;
        Load();
    }

    void Load()
    {
        timeStart = Time.time;
        timeCurrentLevel = myLevelList[numCurrentLevel].Duration;
        nbWaveMax = myLevelList[numCurrentLevel].NbWaves;
        nbWave = 0;

        StartCoroutine(LoadCurrentLevel(myLevelList[numCurrentLevel]));
       
    }

    public IEnumerator LoadCurrentLevel(LevelDescription myLevel)
    {
        for (int i = 0; i < myLevel.Enemies.Length ; i++)
        {
            EnemyDescription enemy = myLevel.Enemies[i];
            while (enemy.SpawnDate > Time.time - timeStart)
            {
                yield return new WaitForSeconds(0.5f);
            }
            mySpawn.FonctionSpawn(enemy.SpawnPosition, enemy.PrefabPath);
            nbWave = enemy.Wave;
            
        }

        NextLevel();
    }

    void NextLevel()
    {
        Debug.Log("next");
        if(numCurrentLevel < myLevelList.Count - 1)
        {
            numCurrentLevel++;
            Load();
        } else
        {
            Win = true;
        }
        
    }
}
