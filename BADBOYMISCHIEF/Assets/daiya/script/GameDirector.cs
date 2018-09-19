using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameDirector : MonoBehaviour {

    // スコア
    public static int score = 0;
    // クリアステージのシーン名
    public static string clearStage;
    // ゲームタイム
    public float gameTime = 60.0f;
    // ゲームタイム表示用テキスト
    [SerializeField]
    private Text timeText;
    // スコア表示用テキスト
    [SerializeField]
    private Text scoreText;


    void Start() {
        InitializeVariable();
    }

    void Update() {
        CalculateGameTime();
        ShowGameTime();
        ShowScore();
    }

    // スコアの加算
    public void AddScore(int amount) {
        score += amount;
    }

    //変数を初期化する
    private void InitializeVariable() {
        score = 0;
        clearStage = null;
        sensei.TeacherD = 0;
        sensei.PTTeacherD = 0;
        sensei.ScienceTeacherD = 0;
        sensei.kyoutouD = 0;
        sensei.HeadTeacherD = 0;
        sensei.In = 0;
        clearStage = SceneManager.GetActiveScene().name;
    }

    // ゲームが終了したらリザルトシーンへ遷移する
    private void CalculateGameTime() {
        gameTime -= Time.deltaTime;
        if (gameTime < 0) {
            gameTime = 0;
            ClearStage(clearStage);
            Invoke("GoResult", 0.5f);
        }
    }

    // ゲームタイムを表示する
    private void ShowGameTime() {
        timeText.text = gameTime.ToString("F1") + "秒";
    }

    // スコアを表示する
    private void ShowScore() {
        scoreText.text = score.ToString() + "点";
    }

    // ステージをアンロックする
    private void ClearStage(string stage) {
        if (PlayerPrefs.GetInt("ClearStage") < 1 && stage == "Stage1") {
            PlayerPrefs.SetInt("ClearStage", 1);
        } else if (PlayerPrefs.GetInt("ClearStage") < 2 && stage == "Stage2") {
            PlayerPrefs.SetInt("ClearStage", 2);
        } else if (PlayerPrefs.GetInt("ClearStage") < 3 && stage == "Stage3") {
            PlayerPrefs.SetInt("ClearStage", 3);
        } else if (PlayerPrefs.GetInt("ClearStage") < 4 && stage == "Stage4") {
            PlayerPrefs.SetInt("ClearStage", 4);
        }
    }

    private void GoResult() {
        SceneManager.LoadScene("Result");

    }
}
