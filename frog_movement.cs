using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class frog_movement : MonoBehaviour
{
    public Vector3 startPos;
    private bool grounded;
    public bool moving;
    GameObject player_obj;
    frog_animation f_anim;
    private float prev_y;
    private int isRight = 1;

    public UnityEvent OnLandEvent;
    
    void Awake()
    {
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
    }
    
    void Start()
    {
        prev_y = this.gameObject.transform.position.y;
        f_anim = this.gameObject.GetComponent<frog_animation>();
        player_obj = GameObject.Find("player");
        moving = false;
        grounded = true;
        startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = player_obj.transform.position;
        Vector3 frogPos = this.gameObject.transform.position;
        if(prev_y > frogPos.y)
        {
            f_anim.upwards = false;
        }
        else if(prev_y == frogPos.y)
        {
            grounded = true;
            f_anim.grounded = true;
            f_anim.idle = true;
            moving = false;
        }
        else
        {
            f_anim.upwards = true;
        }
        if(Math.Abs(playerPos.x-frogPos.x) < 9 && Math.Abs(playerPos.y-frogPos.y) < 3 && !moving)
        {
            if(playerPos.x-frogPos.x > 0)
            {
                this.gameObject.transform.localScale = new Vector3(Math.Abs(this.gameObject.transform.localScale.x)*-1,this.gameObject.transform.localScale.y,this.gameObject.transform.localScale.z);
                isRight = 1;
            }
            else 
            {
                this.gameObject.transform.localScale = new Vector3(Math.Abs(this.gameObject.transform.localScale.x),this.gameObject.transform.localScale.y,this.gameObject.transform.localScale.z);
                isRight = -1;
            }
            moving = true;
        }
        if(moving)
        {
            f_anim.idle = false;
            if(grounded)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 16000f));
                grounded = false;
                f_anim.grounded = false;
                f_anim.upwards = true;
            }
            else
            {
                Vector3 newPos = new Vector3(frogPos.x+(isRight*.1f), frogPos.y, frogPos.z);
                this.gameObject.transform.position = newPos;
            }
        }
        prev_y = frogPos.y;
    }
}
