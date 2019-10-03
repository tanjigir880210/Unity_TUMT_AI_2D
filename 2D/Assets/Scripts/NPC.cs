using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("對話內容")]
    public string start = "嗨! 我需要你幫忙";
    public string not_complete = "你還沒找到10顆水果";
    public string complete = "感謝你幫我完成尋找";

    [Header("對話速度")]
    public float speed = 1.5f;

    [Header("任務相關")]
    public bool missing_complete = true;
    public string count_player = "0";
    public string count_finish = "100";

}
