using UnityEngine;

public class fox : MonoBehaviour
{
    public int speed = 1;
    public float jump = 2.5f;
    public string foxName = "林北是狐狸啦";
    public bool pass = false;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        tra = GetComponent<Transform>()
    }

    private void Update()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}