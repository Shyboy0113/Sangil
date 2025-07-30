using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Rigidbody2D rb;
    
    // 동전 관련
    public int score = 0;
    public int ClearScore = 20;

    // 클리어 UI
    public Canvas finishUI;
    public Canvas overUI;
    
    //체력 관련
    public float maxHp = 100;
    public float hp;

    public float DeadHeight = -100f;
    
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = maxHp;
        score = 0;
    }
    private void FixedUpdate()
    {
        OnDown();
    }
    public void Update()
    {
        HandleMove();
        HandleJump();
    }
    private void OnDown()
    {
        if(transform.position.y < DeadHeight)
        {
            hp = 0; // 체력 0으로 설정
            overUI.gameObject.SetActive(true);
            Time.timeScale = 0; // 시간 정지
        }
    }

    private void HandleMove()
    {
        float h = Input.GetAxis("Horizontal");
        var vel = rb.velocity;
        vel.x = h * moveSpeed;
        
        rb.velocity = vel;
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            score = score + 10;
            Destroy(other.gameObject);
        }

        if(score >= ClearScore)
        {
            if (other.tag == "Finish")
            {
                finishUI.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            hp -= 10;
            //-----------
            
            if (hp <= 0)
            {
                overUI.gameObject.SetActive(true);
                Time.timeScale = 0; //시간 정지
            }
        }
    }
}
