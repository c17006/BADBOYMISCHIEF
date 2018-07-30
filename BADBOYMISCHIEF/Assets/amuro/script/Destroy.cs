using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour {

    public GameObject obj;
    public int score = 10;
    private GameDirector GD;

	// Use this for initialization
	void Start () {
        GD = GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }
	
	// Update is called once per frame
	void Update () {
		if(obj.transform.position.y <= -1000)
        {
            GD.AddScore(score);
            Destroy(obj);
        }
	}
}
