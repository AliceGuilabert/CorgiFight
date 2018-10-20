using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour {

    PlayerAvatar myCorgi;
    Rigidbody2D myRigid;
    public int nbVie;
    public int nbPuissance;

	// Use this for initialization
	void Start () {
        myRigid = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        myRigid.velocity = new Vector2(-1 *6, 2 * Mathf.Sin(5 * Time.time));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerAvatar>().ObjectEffect(nbVie, nbPuissance);
            Destroy(gameObject);
        }
    }
}
