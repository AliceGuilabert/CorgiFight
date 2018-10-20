using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private Vector2 speed;
    Engine myEngine;
    PlayerShoot myShoot;
    PlayerAvatar myBase;
    private bool isShooting;

    // Use this for initialization
    void Start () {
        myShoot = GetComponent<PlayerShoot>();
        myEngine = GetComponent<Engine>();
        myBase = GetComponent<PlayerAvatar>();
	}
	
	// Update is called once per frame
	void Update () {
        speed = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        myEngine.move(speed, -1);

        if (Input.GetKey(KeyCode.Space))
        {
            isShooting = true;
            myShoot.Shoot();
        }
        else
        {
            isShooting = false;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            myShoot.UpdateTir();
        }

        myShoot.lastShoot++;
        myBase.Energy(isShooting);

    }
}
