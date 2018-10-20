using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour {

    PlayerAvatar myCorgi;
    int TimeSurvived;
    int NbWavesSurvived;
    int Score;
    private void Start()
    {
        myCorgi = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAvatar>();
    }

    public void Victory(float TimeSurvived_, int NbWavesSurvived_, int Score_)
    {
        Time.timeScale = 0;
        transform.GetChild(4).gameObject.SetActive(true);
        TimeSurvived = (int) TimeSurvived_;
        Debug.Log(NbWavesSurvived_);
        NbWavesSurvived = NbWavesSurvived_;
        Score = Score_;
    }

    public void Dead(float TimeSurvived_, int NbWavesSurvived_, int Score_)
    {
        Time.timeScale = 0;
        transform.GetChild(5).gameObject.SetActive(true);
        TimeSurvived = (int) TimeSurvived_;
        NbWavesSurvived = NbWavesSurvived_;
        Score = Score_;
    }

    public void OpenSummary(GameObject open)
    {
        open.SetActive(true);
        transform.GetChild(6).GetChild(0).GetComponent<Text>().text = "You lasted " + TimeSurvived + " seconds\n and survive to " + NbWavesSurvived + " waves !";
        transform.GetChild(6).GetChild(2).GetComponent<Text>().text = "Your score : " + Score ;
        transform.GetChild(6).GetChild(3).GetComponent<Text>().text = "Hight score : " + ScoreSystem.highScore ;
        if(TimeSurvived < 30)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "You don't know how to play ?";
        } else if (TimeSurvived < 50)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "That's not very impressive...";
        }
        else if (TimeSurvived == 69)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "You naughty Corgi ;)";
        }
        else if (TimeSurvived < 80)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "Good skill mate !";
        }
        else if (TimeSurvived < 110)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "Whoou you nailed it !";
        }
        else if (TimeSurvived < 150) {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "You're on fire bro !";
        }
        else if (TimeSurvived < 180)
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "Ohgod, still there ?";
        }
        else
        {
            transform.GetChild(6).GetChild(4).GetComponent<Text>().text = "Seriously, get a life and go outside...";
        }
    }

    public void Open(GameObject open)
    {
        open.SetActive(true);
    }

    public void Close(GameObject close)
    {
        close.SetActive(false);
    }

    public void Reload()
    {
        Time.timeScale = 1;
        myCorgi.currentHealth = 60;
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        myCorgi.currentHealth = 60;
        SceneManager.LoadScene(0);
    }
}
