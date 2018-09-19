using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text normalteacherText;
    [SerializeField]
    private Text peteacherText;
    [SerializeField]
    private Text scienceteacherText;
    [SerializeField]
    private Text assistantprincipalteacherText;
    [SerializeField]
    private Text headteacherText;
    [SerializeField]
    private Text passedCountText;
    [SerializeField]
    private GameObject pop;
    [SerializeField]
    private GameObject nextButton;

    // 評価用の星のイメージ
    [SerializeField]
    private GameObject[] starImages;
    // シーン遷移のディレイ
    private float resultCloseTime = 2.0f;
    // 評価の基準
    private int[,] stageEvaluationStandard = new int[,] {{ 230, 180, 130 },
                                                         { 300, 250, 200 },
                                                         { 300, 250, 200 },
                                                         { 350, 300, 250 },
                                                         { 350, 300, 250 } };


    void Start() {
        HideGameObjects();
        CheckClearStage();
        ShowScoreDetail();
    }

    void Update() {
        CloseResultScene();
    }

    // リザルトシーンを送らせて遷移させる
    private void CloseResultScene() {
        resultCloseTime -= Time.deltaTime;
        if (GameDirector.clearStage == "Stage5" && Input.touchCount > 0 && resultCloseTime <= 0) {
            Destroy(nextButton);
            pop.SetActive(true);
        } else if (Input.touchCount > 0 && resultCloseTime <= 0) {
            pop.SetActive(true);
        }
    }

    // ゲームオブジェクトを非表示にする
    private void HideGameObjects() {
        for (int i = 0; i < starImages.Length; i++) {
            starImages[i].SetActive(false);
        }
        pop.SetActive(false);
    }

    // スコアの詳細を表示する
    private void ShowScoreDetail() {
        scoreText.text = GameDirector.score.ToString() + "点";
        normalteacherText.text = "× " + sensei.TeacherD.ToString();
        peteacherText.text = "× " + sensei.PTTeacherD.ToString();
        scienceteacherText.text = "× " + sensei.ScienceTeacherD.ToString();
        assistantprincipalteacherText.text = "× " + sensei.kyoutouD.ToString();
        headteacherText.text = "× " + sensei.HeadTeacherD.ToString();
        passedCountText.text = "通した数 " + sensei.In.ToString();
    }

    // クリアステージを確認する
    private void CheckClearStage() {
        int stageNumber = int.Parse(GameDirector.clearStage.Substring(GameDirector.clearStage.Length - 1));
        CalculateEvaluation(stageNumber);
    }

    // 評価を計算する
    private void CalculateEvaluation(int stageNumber) {
        // ハイスコアの更新
        if (PlayerPrefs.GetInt("HighScore" + stageNumber) < GameDirector.score) {
            PlayerPrefs.SetInt("HighScore" + stageNumber, GameDirector.score);
        }

        // スコアによって星の数を決める
        if (GameDirector.score >= stageEvaluationStandard[stageNumber - 1, 0]) {
            for (int i = 0; i < starImages.Length; i++) {
                starImages[i].SetActive(true);
            }
        } else if (GameDirector.score >= stageEvaluationStandard[stageNumber - 1, 1]) {
            for (int i = 0; i < starImages.Length - 1; i++) {
                starImages[i].SetActive(true);
            }
        } else if (GameDirector.score >= stageEvaluationStandard[stageNumber - 1, 2]) {
            for (int i = 0; i < starImages.Length - 2; i++) {
                starImages[i].SetActive(true);
            }
        }
    }

    // もう一度同じシーンへ遷移する
    public void GoRestart() {
        SceneManager.LoadScene(GameDirector.clearStage);

    }

    // タイトルシーンへ遷移する
    public void GoTitle() {
        SceneManager.LoadScene("Title");
    }

    // ネクストステージへ遷移する
    public void GoNext() {
        switch (GameDirector.clearStage) {
            case "Stage1":
                SceneManager.LoadScene("Stage2");
                break;
            case "Stage2":
                SceneManager.LoadScene("Stage3");
                break;
            case "Stage3":
                SceneManager.LoadScene("Stage4");
                break;
            case "Stage4":
                SceneManager.LoadScene("Stage5");
                break;
            default:
                break;
        }
    }
}
