using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject obj;
    private GameObject tempObj;
    private bool isRight;
    private GameObject playerObj;
    public bool has_power;
    Vector3 playerPos;
    private int cooldown;
    public laser_control b;
    

    

    void Awake()
    {
        obj = GameObject.Find("laser");
        playerObj = GameObject.Find("player");
        has_power = false;
        cooldown = 0;
    }

    void Update()
    {
        if(Time.timeScale == 1)
        {
            if(has_power)
            {
                playerPos = playerObj.transform.position;
                if(Input.GetKeyDown(KeyCode.Space) && cooldown == 0)
                {
                    cooldown = 25;
                    playerPos = playerObj.transform.position;
                    if(playerObj.transform.localScale.x > 0)
                    {
                        playerPos.x = playerObj.transform.position.x+3;
                        isRight = true;
                    }
                    else
                    {
                        playerPos.x = playerObj.transform.position.x-3;
                        isRight = false;
                    }
                    tempObj = Instantiate(obj, playerPos, Quaternion.identity);
                    b = tempObj.GetComponent<laser_control>();
                    b.isRight = isRight;
                    if(!isRight)
                    {
                        tempObj.transform.localScale = new Vector3(tempObj.transform.localScale.x*-1,tempObj.transform.localScale.y,tempObj.transform.localScale.z);
                    }
                    b.is_clone = true;
                }
            }   
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(cooldown > 0)
        {
            cooldown--;
        }
        
    }
}
