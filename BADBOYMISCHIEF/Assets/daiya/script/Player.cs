using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour {

    // アイテム使用時間
    public float[] itemTime = new float[] { 0, 0, 0, 0 };
    // アイテム使用時間のディレイ
    public float[] itemDelay = new float[] { 2.0f, 2.5f, 5.0f, 5.0f };
    // セレクトアイテムのタグ
    public string selectItemButton;

    // 生成アイテムのリスト
    [SerializeField]
    private GameObject[] itemList;
    // セレクトアイテムのフラグ
    private bool[] isSelectedItems = new bool[] { true, false, false, false };
    // セレクトされているアイテムのイメージ
    [SerializeField]
    private Image selectItemImage;
    // selectItemImegeに当てはめるアイテムイメージ
    [SerializeField]
    private Sprite[] itemImages;
    // セレクト音
    [SerializeField]
    private AudioClip selectSE;
    private AudioSource audiosource;

    // セレクトアイテムのナンバー
    private int itemNumber;

    GameDirector gamedirector;


    void Start() {
        audiosource = GetComponent<AudioSource>();
        gamedirector = GameObject.FindWithTag("GameDirector").GetComponent<GameDirector>();
    }

    void Update() {
        ItemTimer();

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(0)) && gamedirector.gameTime > 0) {
            GenerateItem();
        }
    }

    // セレクトアイテムを変更する
    public void ChageSelectItem() {
        switch (selectItemButton) {
            case "GumButton":
                itemNumber = 0;
                break;
            case "BakutikuButton":
                itemNumber = 1;
                break;
            case "DogButton":
                itemNumber = 2;
                break;
            case "CoinButton":
                itemNumber = 3;
                break;
            default:
                break;
        }
        selectItemImage.sprite = itemImages[itemNumber];
        PlaySound(selectSE);
        CheckSelectedItem(itemNumber);
    }

    // 有効なアイテムを確認する
    private void CheckSelectedItem(int itemNumber) {
        for (int i = 0; i < isSelectedItems.Length; i++) {
            if (i == itemNumber) {
                isSelectedItems[i] = true;
            } else {
                isSelectedItems[i] = false;
            }
        }
    }

    // アイテムの使用時間の計算をする
    private void ItemTimer() {
        for (int i = 0; i < itemTime.Length; i++) {
            if (itemTime[i] > 0) {
                itemTime[i] -= Time.deltaTime;
            }
        }
    }

    // アイテムを生成する
    private void GenerateItem() {
        if (GetTouchedPoint().y <= 650 && GetTouchedPoint().y >= -600) {
            if (isSelectedItems[itemNumber] && itemTime[itemNumber] <= 0) {
                Instantiate(GetSelectItme(), GetTouchedPoint(), Quaternion.identity);
                itemTime[itemNumber] = itemDelay[itemNumber];
            }
        }
    }

    // 生成されるアイテムを返す
    private GameObject GetSelectItme() {
        return itemList[Array.IndexOf(isSelectedItems, true)];
    }

    // 生成される位置を返す
    private Vector3 GetTouchedPoint() {
        Vector3 touchedPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3 touchedPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        touchedPoint.z = 1.0f;
        return touchedPoint;
    }

    // サウンドを一回再生する
    private void PlaySound(AudioClip SE) {
        audiosource.PlayOneShot(SE);
    }
}
