using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stageselect : MonoBehaviour {
    public AudioClip select;
    private AudioSource audiosource;
    public GameObject HighScore;
    public Text[] stage;
    private bool score = false;
    private int x;
    private string ScoreString;
    private int ScoreInt;

    public GameObject stege2;
    public GameObject stege3;
    public GameObject stege4;
    public GameObject stege5;

    // Use this for initialization
    void Start () {
       

        audiosource = GetComponent<AudioSource>();
        HighScore.SetActive(false);
        x = PlayerPrefs.GetInt("ClearStage");
        //print(x);
        for(int i = 1; i <= 5; i++)
        {
            ScoreInt = PlayerPrefs.GetInt("HighScore" + i);
            ScoreString = ScoreInt.ToString();
            stage[i-1].text = ScoreString;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("ClearStage") == 1) {
            stege2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ClearStage") == 2) {
            stege2.SetActive(true);
            stege3.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ClearStage") == 3) {
            stege2.SetActive(true);
            stege3.SetActive(true);
            stege4.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("ClearStage") == 4) {
            stege2.SetActive(true);
            stege3.SetActive(true);
            stege4.SetActive(true);
            stege5.SetActive(true);
        }



        /*if (Input.GetButtonDown("Fire2"))
        {
            for (int i = 1; i <= 5; i++)
            {
                PlayerPrefs.SetInt("HighScore" + i, 0);
                stage[i - 1].text = "0";
            }

            PlayerPrefs.SetInt("ClearStage", 0);
            x = 0;
            Debug.Log("RESET CLER STAGE");
        }*/
	}

    public void Stage1()
    {
        audiosource.clip = select;
        audiosource.Play();
        SceneManager.LoadScene("Stage1");
        //Debug.Log("GO to Stage1");
    }

    public void Stage2()
    {
        if (x >= 1)
        {
            audiosource.clip = select;
            audiosource.Play();
            SceneManager.LoadScene("Stage2");
            //Debug.Log("GO to Stage2");
        }
    }

    public void Stage3()
    {
        if (x >= 2)
        {
            audiosource.clip = select;
            audiosource.Play();
            SceneManager.LoadScene("Stage3");
            //Debug.Log("GO to Stage3");
        }
    }

    public void Stage4()
    {
        if (x >= 3)
        {
            audiosource.clip = select;
            audiosource.Play();
            SceneManager.LoadScene("Stage4");
            //Debug.Log("GO to Stage4");
        }
    }

    public void Stage5()
    {
        if (x >= 4)
        {
            audiosource.clip = select;
            audiosource.Play();
            SceneManager.LoadScene("Stage5");
            //Debug.Log("GO to Stage5");
        }
    }

    public void Score()
    {
        audiosource.clip = select;
        audiosource.Play();
        if (score)
        {
            HighScore.SetActive(false);
            score = false;
        }
        else
        {
            HighScore.SetActive(true);
            score = true;
        }
    }
}
