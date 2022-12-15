using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class boss_animation : MonoBehaviour
{
    public Sprite[] frog_idle;
    public Sprite[] death_anim;
    public bool hit = false;
    public int frog_idle_ind = 0;
    private SpriteRenderer spriteRenderer;
    public int counter = 0;
    public int color_counter = 0;
    public bool alive;
    public bool started;
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp;
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        alive = true;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerPos = GameObject.Find("player").transform.position;
        Vector3 bossPos = this.gameObject.transform.position;
        if(!started)
        {
            if(bossPos.x-playerPos.x < 43)
            {
                started = true;
            }
        }
        if(alive)
        {
            if(hit)
            {
                spriteRenderer.color = new Color(224f/255f,44f/255f,44f/255f,255/255);
                hit = false;
                color_counter = 8;
            }
            if(color_counter == 0)
            {
                spriteRenderer.color = new Color(1,1,1,1);
            }
            if(color_counter > -1)
            {
                color_counter--;
            }
            if(started)
            {
                if(counter > 18)
                {
                    
                    ChangeSprite(frog_idle[frog_idle_ind]);
                    if(frog_idle_ind == 3)
                    {
                        this.gameObject.GetComponent<boss_power>().execute = true;
                    }
                    frog_idle_ind = (frog_idle_ind+1)%4;
                    counter = 0;

                }
                else 
                {
                    counter++;
                }
            }
            
        }
        else
        {
            if(counter%2 == 0 && counter < 11)
            {
                ChangeSprite(death_anim[counter/2]);
            }
            else if(counter == 12)
            {
                this.gameObject.SetActive(false);
            }
            counter++;
        }
    }
}
