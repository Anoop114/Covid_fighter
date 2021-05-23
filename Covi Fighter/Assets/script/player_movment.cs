using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject fire_pos;
    public Transform feet_pos;
    public LayerMask what_is_ground;
    public float speed;
    public float x_move;
    public float jump_force;
    private bool is_grounded;
    private bool is_jumping;
    private float jump_time_counter;
    public float jump_counter;
    public float check_radius;
    public static float p_health;

    public float line_of_site;
    private Transform enemy_distance;
    public Animator p_animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        p_health = player_die.p_health;
        enemy_distance = GameObject.FindGameObjectWithTag("enemy").transform;
        p_animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_distance){
            float distance_from_enemy = Vector2.Distance(enemy_distance.position,transform.position);
            if(distance_from_enemy < line_of_site){
                p_animator.SetBool("shoot",true);
            }
            else{
                p_animator.SetBool("shoot",false);
            }
        }
        
         is_grounded = Physics2D.OverlapCircle(feet_pos.position,check_radius, what_is_ground);
        if(!Mathf.Approximately(0,x_move)){
            transform.rotation = x_move < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
            fire_pos.transform.rotation = x_move < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
            
        }
        
        if(Input.GetButtonDown("Jump") && is_grounded == true){
            is_jumping = true;
            jump_time_counter = jump_counter;
            rb.velocity = Vector2.up * jump_force;
            // player_animator.SetBool("isjump",false);
        }
        if(Input.GetButton("Jump") && is_jumping == true){
            if(jump_time_counter > 0){
            rb.velocity  = Vector2.up *jump_force;
            jump_time_counter -= Time.deltaTime;
            p_animator.SetBool("jump",true);
            }else{
                is_jumping = false;
                p_animator.SetBool("jump",false);
            }
        }
        if(Input.GetButtonUp("Jump")){
            is_jumping = false;
            p_animator.SetBool("jump",false);
            
            
        }
        if(p_health<0.2f){
            p_animator.SetBool("die",true);
        }
        p_animator.SetFloat("speed",Mathf.Abs(x_move));
        p_health = player_die.p_health;
    }
    void FixedUpdate() {
        x_move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_move * speed,rb.velocity.y);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,line_of_site);
    }
}
