using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_damage_checker : MonoBehaviour
{
    // Start is called before the first frame update
    player_health p_health;
    private List<string> danger_objs = new List<string>{"bird","possum", "frog", "spike", "boss", "fireball"};
    private string obj_tag;
    void OnCollisionEnter2D(Collision2D col)
    {
        obj_tag = col.gameObject.tag;
        if(danger_objs.Contains(obj_tag))
        {
            p_health = this.gameObject.GetComponent<player_health>();
            p_health.took_damage = true;
        }
    }
}
