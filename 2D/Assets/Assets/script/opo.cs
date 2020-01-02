﻿using UnityEngine;
using UnityEngine.UI;   // 引用 介面 API
using System.Collections;

public class opo : MonoBehaviour
{
    #region 欄位
    // 定義列舉
    // 修飾詞 列舉 列舉名稱 { 列舉內容, .... }
    public enum state
    {
        // 一般、尚未完成、完成
        start, notComplete, complete
    }
    // 使用列舉
    // 修飾詞 類型 名稱
    public state _state;

    [Header("對話")]
    public string sayStart = "嗨!!!我要蒐集十顆寶石!!!";
    public string sayNotComplete = "還沒找到十顆寶石嗎!!!";
    public string sayComplete = "感謝找到寶石!!!";
    [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    public AudioClip soundSay;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // 2D 觸發事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 如果碰到物件為"狐狸"
        if (collision.name == "狐狸")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "狐狸")
            SayClose();
    }

    /// <summary>
    /// 對話：打字效果
    /// </summary>
    private void Say()
    {
        // 畫布.顯示
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;


        // 判斷式(狀態)
        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(sayStart));           // 開始對話
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(sayNotComplete));     // 開始對話未完成
                break;
            case state.complete:
                StartCoroutine(ShowDialog(sayComplete));        // 開始對話完成
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();          // 累加每個文字
            aud.PlayOneShot(soundSay, 0.6f);            // 播放一次音效(音效片段，音量)
            yield return new WaitForSeconds(speed);     // 等待
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }


    /// <summary>
    /// 玩家取得道具
    /// </summary>

    public void PlayerGet()
    {
        countPlayer++;
    }

}