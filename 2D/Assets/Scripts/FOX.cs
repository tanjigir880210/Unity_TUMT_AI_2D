using UnityEngine;
using UnityEngine.Events; // 引用 事件 API

public class FOX : MonoBehaviour // 類別 類別名稱
{
    public int speed = 1; // 整數
    public float jump = 2.5f; // 浮點數
    public string foxName = "林北是狐狸啦"; // 字串
    public bool pass = false; // 布林值 - true/false
    public bool isGround;

    public UnityEvent onEat;

    // private Transform tra;
    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    
    // 更新事件:每秒執行約 60 次
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) Turn(0);
        if (Input.GetKeyDown(KeyCode.A)) Turn(180);
    }

    // 固定更新事件:每禎 0.002 秒
    private void FixedUpdate()
    {
        Walk(); //呼叫方法
        Jump(); //呼叫方法
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        Debug.Log("碰到東西了" + collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "櫻桃")
        {
            Destroy(collision.gameObject); // 刪除
            onEat.Invoke(); // 呼叫事件
        }
    }

    /// <summary>
    /// 走路
    /// </summary>
    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump * Input.GetAxis("Jump")));
        }
    }
    //參數語法 ; 類型 名稱
    /// <summary>
    /// 轉彎
    /// </summary>
    /// <param name="direction">方向 , 左轉為 180 , 右轉為 0</param>
    private void Turn(int direction)
    {
        transform.eulerAngles = new Vector3(0, direction, 0);
    }
}