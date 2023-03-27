using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private Rigidbody2D rb;

    public Transform player;
    public HealthSystem playerHealth;
    public Animator playerAnim;

    private bool facingRight = true;

    public float speed;
    public float agrDist;
    public float timer;
    public float damageDelay;
    public int damage;
    bool touchingPlayer;

    [SerializeField] private GameObject menuLose;

    void Start(){
      damageDelay = timer;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        float distToPlayerX = Vector2.Distance(transform.position, player.position);
        if(distToPlayerX < agrDist){      
      if (transform.position.x > player.position.x)
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      else
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            rb.velocity = (Vector2) (player.position - transform.position).normalized * speed;
        }
    }

      void FixedUpdate() {
        if (timer > 0) {
          timer -= Time.fixedDeltaTime;
          if (timer <= 0.7) {
            timer = damageDelay;
            if (touchingPlayer)
              DamagePlayer();
          }
        }
      }

    private void OnCollisionEnter2D(Collision2D c) {
      if (c.gameObject.tag == "Player")
        touchingPlayer = true;
    }

  private void DamagePlayer() {
    playerHealth.health -= damage;
      if (playerHealth.health > 0) {
       playerAnim.SetTrigger("damage");
      } else {
         playerAnim.SetTrigger("die");
         Time.timeScale = 0;
         menuLose.SetActive(true);
      }
  }

    private void OnCollisionExit2D(Collision2D c) {
      if (c.gameObject.tag == "Player")
       touchingPlayer = false;
    }
}
