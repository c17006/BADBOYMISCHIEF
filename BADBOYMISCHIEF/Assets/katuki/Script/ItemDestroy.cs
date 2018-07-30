using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour {
    public bool count = false;
    private float time;
    public float death;
    public AudioClip haiti;
	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().PlayOneShot(haiti);

    }
	
	// Update is called once per frame
	void Update () {
        if (count)
        {
            time += Time.deltaTime;
            if(time >= death)
            {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        count = true;   
    }
}
