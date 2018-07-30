using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testStage1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("ClearStage", 1);
	}
	
	// Update is called once per frame
	void Update () {
        SceneManager.LoadScene("stage slect");
	}
}
