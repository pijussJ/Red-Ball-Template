using UnityEngine;
using UnityEngine.SceneManagement;

public class Circle : MonoBehaviour
{
    public int speed;
    Rigidbody2D rb;
    public bool isGrounded;
    public GameObject particles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        rb.AddForce(new Vector2(hor,0) * speed);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity += Vector2.up * speed;
        }
     
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.collider.name.Contains("Spike"))
        {
            Invoke("Die", 1f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.Win();
    }
    void Die()
    {
        GameManager.instance.hp--;
        SceneManager.LoadScene(GameManager.instance.currentLevel);

        if (GameManager.instance.hp == 0)
        {
            GameManager.instance.Lose();
        }
    }
}
