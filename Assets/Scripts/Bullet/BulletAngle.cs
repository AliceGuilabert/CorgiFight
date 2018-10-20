using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAngle : Bullet {

    // Update is called once per frame
    void Update()
    {
        myRigid.velocity = new Vector2(speed * Mathf.Cos(angle), speed * Mathf.Sin(-angle));
    }
}
