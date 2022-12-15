using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class laser_control : MonoBehaviour
{
    public bool is_clone = false;
    public bool isRight;
    private Vector3 tempPos;
    private Vector3 playerPos;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(is_clone)
        {
            playerPos = player.transform.position;
            tempPos = this.gameObject.transform.position;
            if(Math.Abs(playerPos.x - tempPos.x) > 50)
            {
                Destroy(this.gameObject);
            }
            else
            {
                tempPos.x += (isRight) ? .5f : -.5f;
                this.gameObject.transform.position = tempPos;
            }
        }
    }
}
