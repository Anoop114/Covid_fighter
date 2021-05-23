using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float line_of_site;
    public float enemy_speed;
    public GameObject player;
    private Transform player_distance;
    public static int e_health = 10;
    // public Rigidbody2D emeny_body;
    // Start is called before the first frame update
    void Start()
    {
        // emeny_body =GetComponent<Rigidbody2D>();
        player_distance = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player){
            float distance_from_player = Vector2.Distance(player_distance.position,transform.position);
            if(distance_from_player < line_of_site){
                transform.position = Vector2.MoveTowards(this.transform.position,player_distance.position,enemy_speed*Time.deltaTime);
            }
        }if(e_health<=0){
            Destroy(gameObject);

        }
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,line_of_site);
    }
    // public void takedamage(int damage){
    //     e_health -= damage;
    //     if(e_health <= 0){
    //         Destroy(gameObject);
    //     }
    // }
}
