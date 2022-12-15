using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bird_movement : MonoBehaviour
{
    public Vector3 startPos;
    public bool isRight;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 targetPos;
    private Vector3 tempPos;
    public bool started;
    private int speed = 30; // higher number equals lower speed.
    private float y_move;
    private float x_move;
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        started = false;
        player = GameObject.Find("player");
        startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive)
        {
            playerPos = player.transform.position;
            if(Math.Abs(playerPos.x-startPos.x) < 12 && Math.Abs(playerPos.y-startPos.y) < 8 && !started)
            {
                if(playerPos.x-startPos.x > 0)
                {
                    this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x*-1,this.gameObject.transform.localScale.y,this.gameObject.transform.localScale.z);
                }
                x_move = (playerPos.x-startPos.x)/speed;
                y_move = (playerPos.y-startPos.y)/speed;
                started = true;
            }
            if(started)
            {
                tempPos = this.gameObject.transform.position;
                tempPos.x += x_move;
                tempPos.y += y_move;
                this.gameObject.transform.position = tempPos;
            }
        }

    }
}
