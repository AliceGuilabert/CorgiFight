using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : BaseAvatar {

    [SerializeField]
    private int maxEnergy;
    public float currentEnergy { get; set; }

    [SerializeField]
    private float energyRecup;
    public float getEnergyRecup()
    {
        return energyRecup;
    }
    public bool zeroEnergy { get; set; }

    public Ui_EnergyLife myUI;

    private void Start()
    {
        currentEnergy = maxEnergy;
        myUI.UpdateHealth(currentHealth);
    }

    public override void Damage(int _damage)
    {
        currentHealth -= _damage;
        Instantiate(degats, transform.position, Quaternion.identity);

        myUI.UpdateHealth(currentHealth);

        if (currentHealth == 0)
        {
            Dead();
        }
    }
    public void Energy(bool isShooting)
    {
        if (!isShooting && !zeroEnergy)
        {
            currentEnergy += energyRecup;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }

        }

        if (zeroEnergy)
        {
            currentEnergy += 0.75f * energyRecup;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
                zeroEnergy = false;
            }
        }

        myUI.UpdateEnergy(currentEnergy, maxEnergy);
    }


    public void ObjectEffect(int nbVie, int nbPuissance)
    {
        currentHealth += nbVie;
        myUI.UpdateHealth(currentHealth);
        currentEnergy += nbPuissance;
        myUI.UpdateEnergy(currentEnergy, maxEnergy);
    }

}
