using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float moveH;
    private Rigidbody2D player;
    
    public float jumpForce; //força do pulo
    public bool pulo, isgrounded;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        // andar - movimento na horizontal (eixo x)
        moveH = Input.GetAxis("Horizontal");
        player.linearVelocity = new Vector2(moveH * speed, player.linearVelocityY);
        
        // pular - movimento na vertical (eixo y)
        pulo = Input.GetButtonDown("Jump");

        if (pulo == true && isgrounded == true)
        {
            player.AddForce(new Vector2(0, jumpForce));
            isgrounded = false;
        }
    }
    // funçao para detectar a colisão
    private void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("floor")) 
        {
            isgrounded = true;
        
        }
    }      
 }