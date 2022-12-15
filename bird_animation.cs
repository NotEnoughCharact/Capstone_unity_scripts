using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_animation : MonoBehaviour
{
    public Sprite[] bird_move;
    public Sprite[] death_anim;
    public bool alive;
    public int bird_ind = 0;
    private SpriteRenderer spriteRenderer;
    public int counter = 0;
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive)
        {
            if(counter > 3)
            {
                ChangeSprite(bird_move[bird_ind]);
                bird_ind = (bird_ind+1)%4;
                counter = 0;
            }
            else 
            {
                counter++;
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
