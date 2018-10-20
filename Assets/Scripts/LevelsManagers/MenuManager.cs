using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    static public int typeJeu;
    static public int difficulty;

    #region Singleton

    public static MenuManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }

    #endregion

    public void LoadScene()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(1);
    }

    public void LoadMenu(GameObject on)
    {
        on.SetActive(true);
    }

    public void SetDifficulté(int i)
    {
        difficulty = i;
    }

    public void SetType(int i)
    {
        typeJeu = i;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
