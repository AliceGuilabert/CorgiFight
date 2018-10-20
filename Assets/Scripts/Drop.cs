using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {

    public GameObject[] drop;

    public void DropObject()
    {
        int prob = Random.Range(0, 50);
        if (prob < 4)
        {
            Instantiate(drop[0], transform.position, Quaternion.identity);
        }
        else if (prob < 8)
        {
            Instantiate(drop[1], transform.position, Quaternion.identity);
        }
    }
}
