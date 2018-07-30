using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject gum;
    public GameObject bakutiku;
    public GameObject dog;
    public GameObject coin;

    bool gumflag;
    bool bakutikuflag;
    bool dogflag;
    bool coinflag;

    public float gumtime;
    public float bakutikutime;
    public float dogtime;
    public float cointime;

    public Image itemeImg;
    public Sprite gumsprite;
    public Sprite bakutikusprite;
    public Sprite dogsprite;
    public Sprite coinsprite;

    GameDirector gd;
    GameObject gamedirector;


    void Start () {
        gumflag = true;
        bakutikuflag = false;
        dogflag = false;
        coinflag = false;

        gumtime = 0;
        bakutikutime = 0;
        dogtime = 0;
        cointime = 0;
        
        gamedirector = GameObject.FindWithTag("GameDirector");
        gd = gamedirector.GetComponent<GameDirector>();

    }

    void Update() {
        ItemTimer();
        ScreenTouch();   
        
    }

    void ScreenTouch() {
        if (Input.touchCount > 0 && gd.gametime > 0) {
            Vector3 ScreenPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            ScreenPoint.z = 1.0f;
           
            if (ScreenPoint.y >= -600 && ScreenPoint.y <= 650) {
                if (gumflag && gumtime <= 0) {
                    Instantiate(gum, ScreenPoint, Quaternion.identity);
                    gumtime = 2.0f;

                }
                else if (bakutikuflag && bakutikutime <= 0) {
                    Instantiate(bakutiku, ScreenPoint, Quaternion.identity);
                    bakutikutime = 2.5f;

                }
                else if (dogflag && dogtime <= 0) {
                    Instantiate(dog, ScreenPoint, Quaternion.identity);
                    dogtime = 5.0f;

                }
                else if (coinflag && cointime <= 0) {
                    Instantiate(coin, ScreenPoint, Quaternion.identity);
                    cointime = 5.0f;
                    
                }
            }
        }        
    }

    void ItemTimer() {
        if (gumtime > 0) 
            gumtime -= Time.deltaTime;
        
        if (bakutikutime > 0)
            bakutikutime -= Time.deltaTime;

        if (dogtime > 0)
            dogtime -= Time.deltaTime;

        if (cointime > 0)
            cointime -= Time.deltaTime;

    }

    public void Gum() {
        itemeImg.sprite = gumsprite;
        GetComponent<AudioSource>().Play();
        gumflag = true;
        bakutikuflag = false;
        dogflag = false;
        coinflag = false;

    }

    public void Bakutiku() {
        itemeImg.sprite = bakutikusprite;
        GetComponent<AudioSource>().Play();
        bakutikuflag = true;
        gumflag = false;
        dogflag = false;
        coinflag = false;

    }

    public void Dog() {
        itemeImg.sprite = dogsprite;
        GetComponent<AudioSource>().Play();
        dogflag = true;
        gumflag = false;
        bakutikuflag = false;
        coinflag = false;

    }

    public void Coin() {
        itemeImg.sprite = coinsprite;
        GetComponent<AudioSource>().Play();
        coinflag = true;
        gumflag = false;
        bakutikuflag = false;
        dogflag = false;

    }
}
