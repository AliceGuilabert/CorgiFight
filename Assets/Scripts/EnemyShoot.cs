using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    [SerializeField]
    private bool isShooting;
    [SerializeField]
    private float shootFrequence;

    public GameObject myStart;

    // Use this for initialization
    void Start () {
		if (isShooting)
        {
            shootFrequence = shootFrequence + (Random.Range(-1, 1));
            InvokeRepeating("Shoot", 0, shootFrequence);
        }
	}

    private void Shoot()
    {
        BulletFactory.Instance.GetBullet(BulletType.TUNA, myStart.transform.position);
    }
}
