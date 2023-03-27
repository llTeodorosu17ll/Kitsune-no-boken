using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour{

    private float movement;

    public bool useKeyboard;

    public float Speed = 1f;
    private bool moveLeft;
    private bool moveRight;

    public float jumpForce;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    bool touchingPortal;

    public Animator Anim;

    private Rigidbody2D rb;

    [SerializeField] private GameObject WinMenu;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false; 
    }

    private void FixedUpdate(){
        //Ось предостваляющия перемещиние влево и вправо
        rb.velocity = new Vector2(movement * Speed, rb.velocity.y);
        
        Anim.SetBool("isRunning", movement != 0);
        Anim.SetBool("isJumping", !isGrounded);
    }

    void Update()
    {
        if (useKeyboard)
        {
            movement = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            MovePlayer();
        }
        if (movement != 0)
            transform.eulerAngles = new Vector3(0, movement > 0 ? 0 : 180, 0);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    } 

    private void OnCollisionEnter2D(Collision2D p){
        if (p.gameObject.tag == "Portal") { 
            touchingPortal = true;
            Time.timeScale = 0;
            WinMenu.SetActive(true);
        }

    }

    public void Jump(){
        if(isGrounded){  // Делаем прыжок
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    public void PointerDownLeft(){
        moveLeft = true;
    }
    public void PointerUpLeft(){
        moveLeft = false;
    }
    public void PointerDownRight(){
        moveRight = true;
    }
    public void PointerUpRight(){
        moveRight = false;
    }
    private void MovePlayer(){
        if (moveLeft){
            movement = -1;
        }
        else if (moveRight){
            movement = 1;
        }
        else{
            movement = 0;
        }
    }

}
