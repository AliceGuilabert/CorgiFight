using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour {

    [SerializeField]
    private int maxLife;
    public int currentHealth { get; set; }
   
    /// <summary>
    public ParticleSystem degats;

    [SerializeField]
    private float maxSpeed;
    public float getMaxSpeed()
    {
        return maxSpeed;
    }


    // Use this for initialization
    void Awake () {
        currentHealth = maxLife;       
    }

    public abstract void Damage(int _damage);

    protected void Dead()
    {
        Destroy(gameObject);
    }

    
}
