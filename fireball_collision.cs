using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_collision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        player_health p_health;
        if(col.name == "player")
        {
            p_health = col.GetComponent<player_health>();
            p_health.took_damage = true;
        }
        if(this.gameObject.GetComponent<fireball_control>().is_clone == true && col.tag != "fireball" && col.tag != "laser" && col.tag != "boss")
        {
            Destroy(this.gameObject);
        }
        
    }
}
