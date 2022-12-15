using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fireball_control : MonoBehaviour
{
    public bool is_clone = false;
    public bool just_fired = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float playerPosX = GameObject.Find("player").transform.position.x;
        float bossPosX = this.gameObject.transform.position.x;
        if(just_fired)
        {
            just_fired = false;
            float left_force = (playerPosX-bossPosX)*30f;
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(left_force, 0f));
            this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));
		}
    }
}
