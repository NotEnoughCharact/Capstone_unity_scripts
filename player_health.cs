using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour
{
    public int health;
    private int invincibility;
    public bool took_damage;
    CharacterController2D character;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        invincibility = 0;
        took_damage = false;
        health = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(took_damage && invincibility == 0)
        {
            spriteRenderer.color = new Color(224f/255f,44f/255f,44f/255f,255/255);
            character = this.gameObject.GetComponent<CharacterController2D>();
            character.hurt_counter = 8;
            character.is_hurt = true;
            invincibility = 48;
            health--;
        }
        else if(invincibility > 0)
        {
            invincibility--;
        }
        else if(invincibility == 0)
        {
            spriteRenderer.color = new Color(1,1,1,1);
        }
        took_damage = false;
    }
}
