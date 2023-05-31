using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]
    private float _speed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;

    void Start()
    { _rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    
        
    }
    void Update()
    {   
        FishSwim();
        FishRotation();
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver ==false)
        { 
            _rb.velocity = Vector2.zero;
            _rb.velocity = new Vector2(_rb.velocity.x,_speed);
        }
    }
    void FishRotation()
    {
       if (_rb.velocity.y > 0)
        {
            if(angle <= maxAngle)
            {
              angle = angle + 4;
            }
        }else if (_rb.velocity.y < -1.2)
            {
                 if(angle >= minAngle)
                 {
                    angle = angle - 2;
                 }
            }
       if(touchedGround == false)
       {
            transform.rotation = Quaternion.Euler(0, 0, angle);
       }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Debug.Log("Scored");
            score.Scored();
        }
        else if (collision.CompareTag("Column"))
        {
            gameManager.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player died.");
            if (GameManager.gameOver==false)
            {
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }
    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        anim.enabled = false;
    }
}
