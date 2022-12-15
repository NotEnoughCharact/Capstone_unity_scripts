using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possum_animation : MonoBehaviour
{
    public Sprite[] possum_move;
    public Sprite[] death_anim;
    public bool hit = false;
    public int possum_ind = 0;
    private SpriteRenderer spriteRenderer;
    public int counter = 0;
    public int color_counter = 0;
    public bool alive;
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive)
        {
            if(counter > 7)
            {
                ChangeSprite(possum_move[possum_ind]);
                possum_ind = (possum_ind+1)%6;
                counter = 0;
            }
            else 
            {
                counter++;
            }
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
