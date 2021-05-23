using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_die : MonoBehaviour
{

    public static float p_health = 1f;
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("enemy")){
            if(p_health > 0f){
                p_health -= 0.2f*Time.deltaTime;
            }else{
                Destroy(gameObject);
                SceneManager.LoadScene("intro");
            }
        }   
    }
}
