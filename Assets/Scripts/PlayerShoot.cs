using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject myStart;
    PlayerAvatar myBase;

    private int TypeTir;

    public int energyTir1;
    public int energyTir2;
    public int energyTir3;

    public int rateTir1;
    public int rateTir2;
    public int rateTir3;

    public int lastShoot { get; set; }
    private bool isShooting;
    public bool getIsShooting()
    {
        return isShooting;
    }

    public void Start()
    {
        myBase = GetComponent<PlayerAvatar>();
        TypeTir = 0;
        UpdateTir();
        lastShoot = 30;
    }

    public void Shoot()
    {
        if(myBase.zeroEnergy)
        {
            isShooting = false;
            return;
        }

        if(TypeTir % 3 == 1 && lastShoot > rateTir1)
        {
            Bullet myBullet = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet.GetComponent<Bullet>().Angle(0);
            myBase.currentEnergy -= energyTir1;
            lastShoot = 0;
        }
        else if (TypeTir % 3 == 2 && lastShoot > rateTir2)
        {
            Bullet myBullet = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet.GetComponent<Bullet>().Angle(0.5f);
            Bullet myBullet2 = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet2.GetComponent<Bullet>().Angle(-0.5f);
            lastShoot = 0;
            myBase.currentEnergy -= energyTir2;
        }

        else if (TypeTir % 3 == 0 && lastShoot > rateTir3)
        {
            Bullet myBullet = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet.GetComponent<Bullet>().Angle(1);
            Bullet myBullet2 = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet2.GetComponent<Bullet>().Angle(-1);
            Bullet myBullet3 = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet3.GetComponent<Bullet>().Angle(0.2f);
            Bullet myBullet4 = BulletFactory.Instance.GetBullet(BulletType.BONE, myStart.transform.position);
            myBullet4.GetComponent<Bullet>().Angle(-0.2f);
            lastShoot = 0;
            myBase.currentEnergy -= energyTir3;
        }

        if(myBase.currentEnergy <= 0)
        {
            myBase.zeroEnergy = true;
        }

        myBase.Energy(isShooting);

        

    }



    public void UpdateTir()
    {
        TypeTir++;
    }
}
