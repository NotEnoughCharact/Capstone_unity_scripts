using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_health : MonoBehaviour
{
    public int health;
    public bool took_damage;
    public bool alive;
    frog_animation p_anim;
    player_score p_score;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        p_anim = this.gameObject.GetComponent<frog_animation>();
        p_score = GameObject.Find("player").GetComponent<player_score>();
        took_damage = false;
        health = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(took_damage)
        {
            health--;
            took_damage = false;
        }
        if(health == 0 && alive)
        {
            p_score.score += 20;
            alive = false;
            p_anim.alive = false;
            p_anim.counter = 0;
        }
    }
}
