using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_collision : MonoBehaviour
{
    boss_animation f_anim;
    boss_health f_health;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "laser(Clone)")
        {
            f_health = this.gameObject.GetComponent<boss_health>();
            f_anim = this.gameObject.GetComponent<boss_animation>();
            f_anim.hit = true;
            f_health.took_damage = true;
        }
    }
}
