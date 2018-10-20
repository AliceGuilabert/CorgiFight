using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Shoot"))
        {
            BulletFactory.Instance.AddAvailableBullet(collision.gameObject, BulletType.BONE);
        } else if (collision.tag.Equals("ShootEnemy"))
        {
            BulletFactory.Instance.AddAvailableBullet(collision.gameObject, BulletType.TUNA);
        }
        else if (collision.tag.Equals("Enemy"))
        {
            EnemyFactory.Instance.AddAvailableEnemy(collision.gameObject, collision.GetComponent<EnemyAvatar>().GetPrefabPath());
        }
    }

}
