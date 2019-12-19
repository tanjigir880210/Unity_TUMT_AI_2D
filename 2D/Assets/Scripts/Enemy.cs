using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("移動素度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("傷害"), Range(0, 100)]
    public float damage = 20f;

    /// <summary>
    /// 隨機移動
    /// </summary>
    private void Move()
    {

    }

    /// <summary>
    /// 追蹤
    /// </summary>
    private void Track()
    {

    }
}
