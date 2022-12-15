using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_collision : MonoBehaviour
{
    frog_animation f_anim;
    frog_health f_health;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "laser(Clone)")
        {
            f_health = this.gameObject.GetComponent<frog_health>();
            f_anim = this.gameObject.GetComponent<frog_animation>();
            f_anim.hit = true;
            f_health.took_damage = true;
        }
    }
}
