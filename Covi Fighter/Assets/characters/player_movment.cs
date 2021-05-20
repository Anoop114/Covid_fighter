using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    public Rigidbody2D rb;
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



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = Physics2D.OverlapCircle(feet_pos.position,check_radius, what_is_ground);
        if(!Mathf.Approximately(0,x_move)){
            transform.rotation = x_move < 0 ? Quaternion.Euler(0,180,0) : Quaternion.identity;
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
            // player_animator.SetBool("isjump",true);
            }else{
                is_jumping = false;
                // player_animator.SetBool("isjump",false);
            }
        }
        if(Input.GetButtonUp("Jump")){
            is_jumping = false;
            
        }
    }
    void FixedUpdate() {
        x_move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x_move * speed,rb.velocity.y);
        // player_animator.SetFloat("run",Mathf.Abs(x_move));
    }
}
