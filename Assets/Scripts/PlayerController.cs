using UnityEngine;
using UnityEngine.SceneManagement; // Sirve para reiniciar el juego cuando se muere la mariquita

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de la mariquita
    private Rigidbody2D rb;
    private Vector2 moveInput; 
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Para leer WASD o flechas
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical"); 


        
        moveInput = new Vector2(moveX, moveY).normalized;
        moveVelocity = moveInput * speed;   
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        Debug.Log("¡Has muerto!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Para reiniciar el nivel
        
        }


    }
}
