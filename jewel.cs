using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jewel : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] jewel_move;
    public Sprite[] aquired;
    public int jewel_ind = 0;
    private SpriteRenderer spriteRenderer;
    public int counter = 0;
    private GameObject player;
    private Vector3 jewelPos;
    private Vector3 playerPos;
    private string s_temp;
    Spawner spawn;
    player_score p_score;
    public bool is_aquired = false;
    
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!is_aquired)
        {
            playerPos = player.transform.position;
            jewelPos = this.gameObject.transform.position;
            if(playerPos.x-jewelPos.x < 1.6  && playerPos.x-jewelPos.x > -1.6 && playerPos.y-jewelPos.y > -1.12 && playerPos.y-jewelPos.y < 1.12)
            {
                p_score = player.GetComponent<player_score>();
                p_score.score += 100;
                is_aquired = true;
                counter = 0;
            }
            if(counter > 24)
            {
                ChangeSprite(jewel_move[jewel_ind]);
                jewel_ind = (jewel_ind+1)%5;
                counter = 0;
            }
            else 
            {
                counter++;
            }
        }
        else
        {
            if(counter%4 == 0 && counter < 13)
            {
                ChangeSprite(aquired[counter/4]);
            }
            else if(counter == 13)
            {
                this.gameObject.SetActive(false);
            }
            counter++;
        }
    }
}
