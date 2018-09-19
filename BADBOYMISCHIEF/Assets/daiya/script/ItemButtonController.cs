using UnityEngine;

public class ItemButtonController : MonoBehaviour {

    private Player player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void OnPushItemButton() {
        player.selectItemButton = gameObject.tag;
        player.ChageSelectItem();
    }
}
