using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour{

    private int rate;
    private float nbEnemy;

    public int nbWaves { get; set; }
    public GameObject[] enemies;

    public void ChangeSpawn(int rate_, int waves_)
    {
        rate = rate_;
        nbEnemy = waves_;
    }

    [SerializeField]
    private string enemyPath1;
    [SerializeField]
    private string enemyPath2;
    [SerializeField]
    private string enemyPath3;
    [SerializeField]
    private string enemyPath4;

    public void BeginRandom()
    {
        InvokeRepeating("RandomSpawn", rate, rate);
    }


    public void FonctionSpawn(Vector2 position, string prefabPath)
    {
        EnemyAvatar enemy = EnemyFactory.Instance.GetEnemy(prefabPath, position);
    }

    void RandomSpawn()
    {
        for (int i = 0; i < nbEnemy; i++)
        {
           
             int enemy = (int)Random.Range(0, 11);
             if (enemy < 4) EnemyFactory.Instance.GetEnemy(enemyPath1, new Vector3(12, Random.Range(-3.94f, 3.94f), 0));
             else if (enemy < 7) EnemyFactory.Instance.GetEnemy(enemyPath2, new Vector3(12, Random.Range(-3.94f, 3.94f), 0));
            else if (enemy < 10) EnemyFactory.Instance.GetEnemy(enemyPath3, new Vector3(12, Random.Range(-3.94f, 3.94f), 0));
            else EnemyFactory.Instance.GetEnemy(enemyPath4, new Vector3(12, Random.Range(-3.94f, 3.94f), 0));
        }
    }
    }
