using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cherry : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] cherry_move;
    public Sprite[] aquired;
    public int cherry_ind = 0;
    private SpriteRenderer spriteRenderer;
    public int counter = 0;
    private GameObject player;
    private GameObject cherryObj;
    private Vector3 cherryPos;
    private Vector3 playerPos;
    Spawner spawn;
    public bool is_aquired = false;
    void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        player = GameObject.Find("player");
        cherryObj = this.gameObject;
        spawn = player.GetComponent<Spawner>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!is_aquired)
        {
            playerPos = player.transform.position;
            cherryPos = cherryObj.transform.position;
            if(playerPos.x-cherryPos.x < 1.6  && playerPos.x-cherryPos.x > -1.6 && playerPos.y-cherryPos.y > -1.12 && playerPos.y-cherryPos.y < 1.12)
            {
                spawn.has_power = true;
                is_aquired = true;
                counter = 0;
            }
            if(counter > 6)
            {
                ChangeSprite(cherry_move[cherry_ind]);
                cherry_ind = (cherry_ind+1)%7;
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
