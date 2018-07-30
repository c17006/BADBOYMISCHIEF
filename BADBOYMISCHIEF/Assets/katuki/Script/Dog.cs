using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {
    private float speed = 1;
    sensei senseisc;
    GameObject sennsei1 = null;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()  
    {
        transform.Translate(new Vector2(0, 10 * speed));
        if (transform.position.y >= 1500 || transform.position.y <= -1500)
        {
            //sensei.RestartScientist();
            Destroy(gameObject);
        }

        if (this.gameObject.transform.position.y <= -1200)
        {
            senseisc = sennsei1.GetComponent<sensei>();
            senseisc.xx = 1;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ScienceTeacher")
        {
            speed = 1.5f;
            transform.Rotate(new Vector3(0, 0, 180));
            sennsei1 = other.gameObject;
        }
    }
}
