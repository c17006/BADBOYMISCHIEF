using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    public AudioClip select;
    private AudioSource audiosource;

	// Use this for initialization
	void Start () {
        audiosource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToReturn ()
    {
        audiosource.clip = select;
        audiosource.Play();
        Invoke("GoTitle", 0.5f);       
    }
    private void GoTitle() {
        SceneManager.LoadScene("Title");
    }
}
