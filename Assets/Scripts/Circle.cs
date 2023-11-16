using UnityEngine;

public class Circle : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor,0) * speed);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += Vector2.up * speed;
        }
        
    }
}
