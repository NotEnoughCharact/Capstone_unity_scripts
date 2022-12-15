using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_collision : MonoBehaviour
{
    player_score p_score;
    bird_animation b_anim;
    bird_movement b_move;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "laser(Clone)")
        {
            p_score = GameObject.Find("player").GetComponent<player_score>();
            p_score.score += 20;
        }
        b_anim = this.gameObject.GetComponent<bird_animation>();
        b_anim.counter = 0;
        b_anim.alive = false;
        b_move = this.gameObject.GetComponent<bird_movement>();
        b_move.alive = false;
    }
    
}
