using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensei : MonoBehaviour
{
    public float speed = 1;
    private float time;//スタン時、撃破時の処理用
    private bool stan = false;
    public float xx;
    private bool baku = false;
    private Animator anim;
    private float X = 0;
    private float senseiX;//先生の位置
    private float kaneX;//お金の位置
    private bool Dog = false;
    Player playersc;
    private int recastRan = 0;
    public AudioClip Damage;
    public AudioClip Gum;
    public AudioClip recast;
    public int teacherscore;
    public int ptteacherrscore;
    public int scienceTeacherscore;
    public int kyoutouscore;
    public int headteacherscore;

    public static int TeacherD;
    public static int PTTeacherD;
    public static int ScienceTeacherD;
    public static int kyoutouD;
    public static int HeadTeacherD;

    public static int In;
    GameDirector gumdirectorsc;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        xx = speed;
        anim = GetComponent<Animator>();
        playersc = GameObject.FindWithTag("Player").GetComponent<Player>();
        gumdirectorsc = GameObject.FindWithTag("GameDirector").GetComponent<GameDirector>();

    }

    void Update()
    {
        if (transform.position.y == -900 && this.gameObject.tag == "kyoutou")
        {
            GetComponent<AudioSource>().PlayOneShot(recast);

            playersc.gumtime = 2;
            playersc.bakutikutime = 2.5f;
            playersc.dogtime = 5;
            playersc.cointime = 5;

            /*recastRan = Random.Range(0, 4);
            if (recastRan == 0)
            {
                playersc.gumtime += 1;
                Debug.Log("recastGAMU");
            }
            else if (recastRan == 1)
            {
                playersc.cointime += 1;
                Debug.Log("recastCOIN");
            }
            else if (recastRan == 2)
            {
                playersc.dogtime += 1;
                Debug.Log("recastDOG");

            }
            else if (recastRan == 3)
            {
                playersc.bakutikutime += 1;
                Debug.Log("recastBAKUTIKU");

            }*/
        }
        transform.Translate(new Vector2(X, xx * -10));
        if (stan || baku )
        {
            time += Time.deltaTime;
            X = 0;
            if (stan && time >= 1.5f)
            {
                stan = false;
                xx = speed;
                anim.SetBool("break", false);
            }
            else if (baku && time >= 1)
            {
                if (this.gameObject.tag == "Teacher") {
                    gumdirectorsc.AddScore(teacherscore);
                }

                else if (this.gameObject.tag == "PTTeacher") {
                    gumdirectorsc.AddScore(ptteacherrscore);
                }

                else if (this.gameObject.tag == "ScienceTeacher") {
                    gumdirectorsc.AddScore(scienceTeacherscore);
                }

                else if (this.gameObject.tag == "kyoutou") {
                    gumdirectorsc.AddScore(kyoutouscore);
                }
                else if (this.gameObject.tag == "HeadTeacher") {
                    gumdirectorsc.AddScore(headteacherscore);
                }
                Destroy(gameObject);

            }
        }

        if (transform.position.y <= -1500) {
            In += 1;
        }

        if (transform.position.y >= 1900 || transform.position.y <= -1500)
        {         
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bakuchiku")
        {
            GetComponent<AudioSource>().PlayOneShot(Damage);
            xx = -speed * 1.5f;
            anim.SetBool("nige", true);
            stan = false;
            Scorejudge();
        }
        else if (other.gameObject.tag == "Gum")
        {
            GetComponent<AudioSource>().PlayOneShot(Gum);
            time = 0;
            xx = 0;
            stan = true;
            anim.SetBool("break", true);
        }
        else if (other.gameObject.tag == "Dog" && this.gameObject.tag != "ScienceTeacher")
        {
            Dog = true;
           
            anim.SetBool("nige", true);
            xx = speed * -1 * 1.5f;
            Scorejudge();
        }else if (other.gameObject.tag == "Dog" && this.gameObject.tag == "ScienceTeacher")
        {
            xx = 0;
        }

    }

    void Scorejudge()
    {
        if (this.gameObject.tag == "Teacher")
        {
            TeacherD += 1;
            gumdirectorsc.AddScore(teacherscore);
        }

        else if (this.gameObject.tag == "PTTeacher")
        {
            PTTeacherD += 1;
            gumdirectorsc.AddScore(ptteacherrscore);
        }

        else if (this.gameObject.tag == "ScienceTeacher")
        {
            ScienceTeacherD += 1;
            gumdirectorsc.AddScore(scienceTeacherscore);
        }

        else if (this.gameObject.tag == "kyoutou")
        {
            kyoutouD += 1;
            gumdirectorsc.AddScore(kyoutouscore);
        }
        else if (this.gameObject.tag == "HeadTeacher")
        {
            HeadTeacherD += 1;
            gumdirectorsc.AddScore(headteacherscore);
        }
        //Debug.Log("PPPP");
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "kane") //お金に引き寄せられる処理
        {
            if (stan || baku || Dog) return;
            senseiX = transform.position.x;//位置を取得
            kaneX = other.gameObject.transform.position.x;//
            if (kaneX == senseiX)
            {
                X = 0;
            }
            else if (kaneX > senseiX)
            {
                X = 5;
            }
            else if (kaneX < senseiX)
            {
                X = -5;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        X = 0;//x座標固定
    }
}


