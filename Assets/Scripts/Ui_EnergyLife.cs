using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_EnergyLife : MonoBehaviour {

    public Image energyBar;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Image[] hearts;


    // Use this for initialization
    void Start () {
		
	}

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void UpdateEnergy(float currentEnergy, int maxEnergy)
    {
        energyBar.fillAmount = currentEnergy / maxEnergy;
    }
}
