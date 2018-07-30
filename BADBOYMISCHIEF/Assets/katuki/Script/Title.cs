using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
    public AudioClip select;
    private AudioSource audiosource;

    // Use this for initialization
    
    void Start () {
        audiosource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToStart()
    {

        audiosource.clip = select;
        audiosource.Play();
        Invoke("GoScene", 0.5f);
    }

    public void Tutorial()
    {
        audiosource.clip = select;
        audiosource.Play();
        Invoke("GoTutorial", 0.5f);
    }

  private void GoScene()
    {
        SceneManager.LoadScene("StageSelect");
        //Debug.Log("ToStart");
    }

   private void GoTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        //Debug.Log("ToTutorial");
    }
}
