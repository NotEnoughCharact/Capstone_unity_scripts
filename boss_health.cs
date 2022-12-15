using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health : MonoBehaviour
{
    public int health;
    public bool took_damage;
    public bool alive;
    boss_animation p_anim;
    player_score p_score;
    GameObject bar;
    // Start is called before the first frame update
    void Awake()
    {
        bar = GameObject.Find("boss_health");
        alive = true;
        p_anim = this.gameObject.GetComponent<boss_animation>();
        p_score = GameObject.Find("player").GetComponent<player_score>();
        took_damage = false;
        health = 20;
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
            bar.SetActive(false);
            p_score.score += 200;
            alive = false;
            p_anim.alive = false;
            p_anim.counter = 0;
            GameObject.Find("player").GetComponent<end_game>().ended = true;
        }
    }
}
