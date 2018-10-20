using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyFactory : MonoBehaviour {

    public static EnemyFactory Instance { get; private set; }

    [SerializeField]
    private GameObject cat;
    [SerializeField]
    private GameObject unicat;
    [SerializeField]
    private GameObject scootcat;
    [SerializeField]
    private GameObject magicat;

    [SerializeField]
    private GameObject factory;

    private Dictionary<string, Queue<EnemyAvatar>> availableEnemiesByType = new Dictionary<string, Queue<EnemyAvatar>>();

    private void Awake()
    {
        Debug.Assert(EnemyFactory.Instance == null);

        EnemyFactory.Instance = this;


    }

    public EnemyAvatar GetEnemy(string enemyPath, Vector2 startPosition)
    {
        if (!EnemyFactory.Instance.availableEnemiesByType.ContainsKey(enemyPath))
        {
            EnemyFactory.Instance.availableEnemiesByType.Add(enemyPath, new Queue<EnemyAvatar>());
        }

        GameObject enemyObject = null;
        enemyObject = GetAvailableEnemy(enemyPath);
        enemyObject.SetActive(true);
        enemyObject.transform.position = startPosition;
        EnemyAvatar enemy = enemyObject.GetComponent<EnemyAvatar>();
        return enemy;
    }



    public GameObject GetAvailableEnemy(string enemyPath)
    {
        GameObject enemy = null;
        Queue<EnemyAvatar> availableEnemies = EnemyFactory.Instance.availableEnemiesByType[enemyPath];

        if (availableEnemies.Count > 0)
        {
            enemy = availableEnemies.Dequeue().gameObject;
        }
        if (enemy == null)
        {
            enemy = Instantiate((GameObject)Resources.Load(enemyPath), factory.transform.position, Quaternion.identity);
        }
        return enemy;
    }

    public void AddAvailableEnemy(GameObject enemy, string enemyPath)
    {
        Queue<EnemyAvatar> availableEnemies = EnemyFactory.Instance.availableEnemiesByType[enemyPath];
        availableEnemies.Enqueue(enemy.GetComponent<EnemyAvatar>());
        enemy.SetActive(false);
        enemy.transform.position = factory.transform.position;
    }
}
