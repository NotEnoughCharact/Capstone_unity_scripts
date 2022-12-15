using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possum_collision : MonoBehaviour
{
    possum_animation p_anim;
    possum_health p_health;
    possum_movement p_move;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "laser(Clone)")
        {
            p_health = this.gameObject.GetComponent<possum_health>();
            p_anim = this.gameObject.GetComponent<possum_animation>();
            p_anim.hit = true;
            p_health.took_damage = true;
        }
    }
}
