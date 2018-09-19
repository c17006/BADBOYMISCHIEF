using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBGM : MonoBehaviour {

    public bool DontDestroyEnabled = true;//破棄されない
    private GameObject[] bgmController;
    private int stageFirstNumber = 1;
    private int stageLastNumber = 5;

    void Awake() {
        DontDestroyOnLoad(this);
    }

    void Start() {
        // 同じオブジェクトが２つ存在するとき片方を削除する
        bgmController = GameObject.FindGameObjectsWithTag("BGM");
        if (bgmController.Length == 2) {
            Destroy(gameObject);
        }
    }

    void Update() {
        // ステージ1から5が読み込まれたらオブジェクトを削除する
        string sceneName = SceneManager.GetActiveScene().name;
        for (int i = stageFirstNumber; i <= stageLastNumber; i++) {
            if (SceneManager.GetActiveScene().name == "Stage" + i) {
                Destroy(gameObject);
            }
        }  
    }
}
