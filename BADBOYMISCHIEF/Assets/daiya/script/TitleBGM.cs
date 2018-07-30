using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBGM : MonoBehaviour {

    public bool DontDestroyEnabled = true;
    private GameObject[] bgm;


    void Start() {
        bgm = GameObject.FindGameObjectsWithTag("BGM");
        if (bgm.Length == 2) {
            Destroy(gameObject);

        }
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name == "Stage1" ||
            SceneManager.GetActiveScene().name == "Stage2" ||
            SceneManager.GetActiveScene().name == "Stage3" ||
            SceneManager.GetActiveScene().name == "Stage4" ||
            SceneManager.GetActiveScene().name == "Stage5") {
            Destroy(gameObject);

        }

        if (DontDestroyEnabled) {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }
}
