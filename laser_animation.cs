using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_animation : MonoBehaviour
{
    public Sprite[] laser_move;
    private int laser_ind = 0;
    private SpriteRenderer spriteRenderer;
    private int counter = 0;
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(counter > 1)
        {
            ChangeSprite(laser_move[laser_ind]);
            laser_ind = (laser_ind+1)%4;
            counter = 0;
        }
        else 
        {
            counter++;
        }
    }
}
