using UnityEngine;

public class OUT : MonoBehaviour
{
    public float damage = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "狐狸" )
        {
            collision.gameObject.GetComponent<Fox>().Damage(damage);

        }
    }

}
