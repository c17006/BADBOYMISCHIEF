using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    private string evaluation;
    public Text evatext;
    public Text Score;
    private int x;
    public Text Teacher;
    public Text PTTeacher;
    public Text ScienceTeacher;
    public Text kyoutou;
    public Text HeadTeacher;
    public Text In;
    public GameObject Pop;
    public GameObject NextButton;

    public GameObject eva_star0;
    public GameObject eva_star1;
    public GameObject eva_star2;

    private float time;


    void Start() {
        eva_star0.SetActive(false);
        eva_star1.SetActive(false);
        eva_star2.SetActive(false);

        Pop.SetActive(false);

        EvaCal();

        Score.text = GameDirector.score.ToString() + "点";
        Teacher.text = "× " + sensei.TeacherD.ToString();
        PTTeacher.text = "× " + sensei.PTTeacherD.ToString();
        ScienceTeacher.text = "× " + sensei.ScienceTeacherD.ToString();
        kyoutou.text = "× " + sensei.kyoutouD.ToString();
        HeadTeacher.text = "× " + sensei.HeadTeacherD.ToString();
        In.text = "通した数 " + sensei.In.ToString();

    }

    void Update() {
        time += Time.deltaTime;
        if (GameDirector.clearstage == "Stage5" && Input.touchCount > 0 && time >= 2.0f) {
            Destroy(NextButton);
            Pop.SetActive(true);

        }
        else if (Input.touchCount > 0 && time >= 2.0f) {
            Pop.SetActive(true);

        }
    }

    public void EvaCal() {
        switch (GameDirector.clearstage) {
            case "Stage1":
                if (PlayerPrefs.GetInt("HighScore1") < GameDirector.score)
                    PlayerPrefs.SetInt("HighScore1", GameDirector.score);

                if (GameDirector.score >= 230) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                    eva_star2.SetActive(true);
                }
                else if (GameDirector.score >= 180) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                }
                else if (GameDirector.score >= 130) {
                    eva_star0.SetActive(true);
                }
                else if (GameDirector.score < 130) {
                }

                break;

            case "Stage2":
                if (PlayerPrefs.GetInt("HighScore2") < GameDirector.score)
                    PlayerPrefs.SetInt("HighScore2", GameDirector.score);

                if (GameDirector.score >= 300) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                    eva_star2.SetActive(true);
                }
                else if (GameDirector.score >= 250) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                }
                else if (GameDirector.score >= 200) {
                    eva_star0.SetActive(true);
                }
                else if (GameDirector.score < 200) {
                }

                break;

            case "Stage3":
                if (PlayerPrefs.GetInt("HighScore3") < GameDirector.score)
                    PlayerPrefs.SetInt("HighScore3", GameDirector.score);

                if (GameDirector.score >= 300) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                    eva_star2.SetActive(true);
                }
                else if (GameDirector.score >= 250) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                }
                else if (GameDirector.score >= 200) {
                    eva_star0.SetActive(true);
                }
                else if (GameDirector.score < 200) {
                }
                break;

            case "Stage4":
                if (PlayerPrefs.GetInt("HighScore4") < GameDirector.score)
                    PlayerPrefs.SetInt("HighScore4", GameDirector.score);

                if (GameDirector.score >= 350) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                    eva_star2.SetActive(true);
                }
                else if (GameDirector.score >= 300) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                }
                else if (GameDirector.score >= 250) {
                    eva_star0.SetActive(true);
                }
                else if (GameDirector.score < 250) {
                }

                break;

            case "Stage5":
                if (PlayerPrefs.GetInt("HighScore5") < GameDirector.score)
                    PlayerPrefs.SetInt("HighScore5", GameDirector.score);

                if (GameDirector.score >= 350) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                    eva_star2.SetActive(true);
                }
                else if (GameDirector.score >= 300) {
                    eva_star0.SetActive(true);
                    eva_star1.SetActive(true);
                }
                else if (GameDirector.score >= 250) {
                    eva_star0.SetActive(true);
                }
                else if (GameDirector.score < 250) {
                }

                break;
        }
    }

    public void Gotitle() {
        SceneManager.LoadScene("Title");
    }

    public void Gonext() {
        if (GameDirector.clearstage == "Stage1") {
            SceneManager.LoadScene("Stage2");
        }
        else if (GameDirector.clearstage == "Stage2") {
            SceneManager.LoadScene("Stage3");
        }
        else if (GameDirector.clearstage == "Stage3") {
            SceneManager.LoadScene("Stage4");
        }
        else if (GameDirector.clearstage == "Stage4") {
            SceneManager.LoadScene("Stage5");
        }
    }

    public void Gorestart() {
        SceneManager.LoadScene(GameDirector.clearstage);

    }
}
