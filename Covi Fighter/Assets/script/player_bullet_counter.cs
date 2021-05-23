using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet_counter : MonoBehaviour
{
    public static int bullets;

    // Start is called before the first frame update
    void Start()
    {
        bullets = player_bullet.bullet;
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            if(bullets < 20){
                bullets += 1;
                if(player_die.p_health < 1f){
                    player_die.p_health += 0.3f;
                }
                player_bullet.bullet = bullets;
            }
        }
        Destroy(gameObject);
    }

}
