using UnityEngine;
using UnityEngine.UI;

public class ItemTime : MonoBehaviour {

    public Image UIobj;
    Player playercs;


    void Start() {
        playercs = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    void Update() {
        if (gameObject.tag == "BakutikuButton")
            BakutikuCal();

        if (gameObject.tag == "GumButton")
            GumCal();

        if (gameObject.tag == "DogButton")
            DogCal();

        if (gameObject.tag == "CoinButton")
            CoinCal();

    }


    void BakutikuCal() {
        if (UIobj.fillAmount > 0) {
            UIobj.fillAmount -= 1.0f / 2.5f * Time.deltaTime;

        }

        if (playercs.bakutikutime == 2.5f) {
            UIobj.fillAmount = 1.0f;

        }
    }

    void GumCal() {
        if (UIobj.fillAmount > 0) {
            UIobj.fillAmount -= 1.0f / 2.0f * Time.deltaTime;

        }

        if (playercs.gumtime == 2.0f) {
            UIobj.fillAmount = 1.0f;

        }
    }

    void DogCal() {
        if (UIobj.fillAmount > 0) {
            UIobj.fillAmount -= 1.0f / 5.0f * Time.deltaTime;

        }

        if (playercs.dogtime == 5.0f) {
            UIobj.fillAmount = 1.0f;

        }
    }

    void CoinCal() {
        if (UIobj.fillAmount > 0) {
            UIobj.fillAmount -= 1.0f / 5.0f * Time.deltaTime;

        }
        if (playercs.cointime == 5.0f) {
            UIobj.fillAmount = 1.0f;

        }
    }
}
