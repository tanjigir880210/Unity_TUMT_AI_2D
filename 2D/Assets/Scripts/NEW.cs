using UnityEngine;

public class NEW : MonoBehaviour
{
    public int speed = 1;
    public float jump = 2.5f;
    public string foxName = "林北是狐狸啦";
    public bool pass = false;

    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
    }
}