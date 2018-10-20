using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Bullet : MonoBehaviour {

    protected Rigidbody2D myRigid;
    [SerializeField]
    private int damage;
    [SerializeField]
    protected int speed;
    public float angle { get; set; }
    [SerializeField]
    private bool isPlayer;

    private void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(myRigid, "C'est nul");
    }

    public void Angle(float _angle)
    {
        angle = _angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && isPlayer)
        {
            collision.gameObject.GetComponent<BaseAvatar>().Damage(damage);
            BulletFactory.Instance.AddAvailableBullet(gameObject, BulletType.BONE);

        } else if (collision.gameObject.tag == "Player" && !isPlayer)
        {
            collision.gameObject.GetComponent<BaseAvatar>().Damage(damage);
            BulletFactory.Instance.AddAvailableBullet(gameObject, BulletType.TUNA);
        }
    }
}
