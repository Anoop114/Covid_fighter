using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_fire : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if(player_bullet.bullet > 0){
            rb.velocity = transform.right*speed;
            player_bullet.bullet -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D hits) {
        // Debug.Log(hits.name);
        if(hits.gameObject.CompareTag("enemy")){
            // enemy enm = new enemy();
            // enm.takedamage(2);
            enemy.e_health -= 2;
            Destroy(gameObject);
        }
    }

}
