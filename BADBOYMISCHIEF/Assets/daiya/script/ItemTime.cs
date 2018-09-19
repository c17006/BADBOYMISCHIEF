using UnityEngine;
using UnityEngine.UI;

public class ItemTime : MonoBehaviour {

    // アイテム使用時間のゲージパネル
    [SerializeField]
    private Image itemDelayImage;
    private Player player;


    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

    }

    void Update() {
        switch (gameObject.tag) {
            case "GumButton":
                CalculateItemReuseHours(player.itemDelay[0], player.itemTime[0]);
                break;
            case "BakutikuButton":
                CalculateItemReuseHours(player.itemDelay[1], player.itemTime[1]);
                break;
            case "DogButton":
                CalculateItemReuseHours(player.itemDelay[2], player.itemTime[2]);
                break;
            case "CoinButton":
                CalculateItemReuseHours(player.itemDelay[3], player.itemTime[3]);
                break;
            default:
                break;
        }
    }

    // アイテム使用時間をゲージで表示
    private void CalculateItemReuseHours(float itemDelay, float itemTime) {
        if (itemDelayImage.fillAmount > 0) {
            itemDelayImage.fillAmount -= 1.0f / itemDelay * Time.deltaTime;
        }

        if (itemTime == itemDelay) {
            itemDelayImage.fillAmount = 1.0f;
        }
    }
}

