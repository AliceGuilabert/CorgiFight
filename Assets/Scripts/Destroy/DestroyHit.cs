using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHit : MonoBehaviour {

    [SerializeField]
    private int lifetime;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
