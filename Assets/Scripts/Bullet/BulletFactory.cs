using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    BONE,
    TUNA
}

public class BulletFactory : MonoBehaviour {

    public static BulletFactory Instance { get; private set; }

    [SerializeField]
    private GameObject bulletPlayer;
    [SerializeField]
    private GameObject bulletEnemy;

    [SerializeField]
    private GameObject factory;

    private List<GameObject> bulletsPlayerList = new List<GameObject>();
    private List<GameObject> bulletsEnemyList = new List<GameObject>();

    private void Awake()
    {
        Debug.Assert(BulletFactory.Instance == null);

        BulletFactory.Instance = this;
    }
    public Bullet GetBullet(BulletType type, Vector3 startPosition)
    {
        GameObject bulletObject = null;
        switch (type)
        {
            case BulletType.BONE:
                bulletObject = GetAvailableBullet(BulletType.BONE);
                bulletObject.SetActive(true);
                bulletObject.transform.position = startPosition;
                break;
            case BulletType.TUNA:
                bulletObject = GetAvailableBullet(BulletType.TUNA);
                bulletObject.SetActive(true);
                bulletObject.transform.position = startPosition;
                break;
            default:
                break;
        }

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        return bullet;
    }



    public GameObject GetAvailableBullet(BulletType type)
    {
        GameObject bullet = null;
        switch (type)
        {
            case BulletType.BONE:
                if(bulletsPlayerList.Count > 0)
                {
                    bullet = bulletsPlayerList[0];
                    bulletsPlayerList.Remove(bullet);
                } else
                {
                   bullet = Instantiate(bulletPlayer, factory.transform.position, Quaternion.identity);
                }
                break;
            case BulletType.TUNA:
                if (bulletsEnemyList.Count > 0)
                {
                    bullet = bulletsEnemyList[0];
                    bulletsEnemyList.Remove(bullet);
                } else
                {
                    bullet = Instantiate(bulletEnemy, factory.transform.position, Quaternion.identity);
                }
                break;
            default:
                break;
        }

        return bullet;
    }

    public void AddAvailableBullet(GameObject bullet, BulletType type)
    {
        switch (type)
        {
            case BulletType.BONE:
                bullet.SetActive(false);
                bullet.transform.position = factory.transform.position;
                bulletsPlayerList.Add(bullet);
                break;
            case BulletType.TUNA:
                bullet.SetActive(false);
                bullet.transform.position = factory.transform.position;
                bulletsEnemyList.Add(bullet);
                break;
            default:
                break;
        }
    }
}
