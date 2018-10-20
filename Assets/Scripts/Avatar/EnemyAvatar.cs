using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar {

    [SerializeField]
    private int nbPoints1;
    public int GetnbPoints()
    {
        return nbPoints1;
    }

    public void SetnbPoints(int value)
    {
        nbPoints1 = value;
    }

    [SerializeField]
    private string prefabPath;

    public string GetPrefabPath()
    {
        return prefabPath;
    }

    [SerializeField]
    private float angle;
    [SerializeField]
    private Vector2 speed;

    ScoreSystem myScore;
    Drop myDrop;
    PolygonCollider2D myCollider;
    Engine myEngine;


    // Use this for initialization
    void Start () {
        myScore = FindObjectOfType<ScoreSystem>().GetComponent<ScoreSystem>();
        myCollider = GetComponent<PolygonCollider2D>();
        myDrop = GetComponent<Drop>();
        myEngine = GetComponent<Engine>();

        Debug.Assert(myCollider);
        Debug.Assert(myScore);
        Debug.Assert(myDrop);
    }

    private void Update()
    {
        myEngine.move(speed, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.GetComponent<PlayerAvatar>().Damage(1);
            //gameObject.SetActive(false);
        }
    }

    public override void Damage(int damage)
    {
        currentHealth -= damage;
        Instantiate(degats, transform.position, Quaternion.identity);
        if (currentHealth == 0)
        {
            Destroy(gameObject);
            myDrop.DropObject();
            myScore.currentScore += GetnbPoints();
        }
    }
}
