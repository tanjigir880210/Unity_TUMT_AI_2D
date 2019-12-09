using UnityEngine;
using UnityEngine.UI; // 引用 介面 API

public class NPC : MonoBehaviour
{
    #region 欄位
    // 定義列舉
    // 修飾詞 列舉 列舉名稱 { 列舉內容, ..... }
    public enum state
    {
        // 一般、尚未完成、完成
        normal, notComplete, complete
    }
    // 使用列舉
    // 修飾詞 類型 名稱
    public state _state;

    [Header("對話內容")]
    public string start = "嗨! 我需要你幫忙";
    public string notcomplete = "你還沒找到10顆水果";
    public string complete = "感謝你幫我完成尋找";

    [Header("對話速度")]
    public float speed = 1.5f;

    [Header("任務相關")]
    public bool missing_complete = true;
    public string count_player;
    public string count_finish = "10";

    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion


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
    /// 對話:打字效果
    /// </summary>
    private void Say()
    {
        // 畫布.顯示
        objCanvas.SetActive(true);

        switch (_state)
        {
            case state.normal:
                textSay.text = start;
                break;
            case state.notComplete:
                textSay.text = notcomplete;
                break;
            case state.complete:
                textSay.text = complete;
                break;
        }
    }

    /// <summary>
    /// 關閉對話
    /// </summary>
    private void SayClose()
    {
        objCanvas.SetActive(false);
    }
}
