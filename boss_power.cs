using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_power : MonoBehaviour
{
    private GameObject obj;
    private GameObject tempObj;
    Vector3 bossPos;
    public bool execute;
    public fireball_control b;
    
    
    void Start()
    {
        execute = false;
        obj = GameObject.Find("fireball");
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        {
            if(execute)
            {
                execute = false;
                bossPos = new Vector3(this.gameObject.transform.position.x-8,this.gameObject.transform.position.y+11,this.gameObject.transform.position.z);
                tempObj = Instantiate(obj, bossPos, Quaternion.identity);
                b = tempObj.GetComponent<fireball_control>();
                b.is_clone = true;
                b.just_fired = true;
                tempObj.GetComponent<Rigidbody2D>().gravityScale = 1.2f;
                tempObj = Instantiate(obj, bossPos, Quaternion.identity);
                b = tempObj.GetComponent<fireball_control>();
                b.is_clone = true;
                b.just_fired = true;
                tempObj.GetComponent<Rigidbody2D>().gravityScale = 2;
                tempObj = Instantiate(obj, bossPos, Quaternion.identity);
                b = tempObj.GetComponent<fireball_control>();
                b.is_clone = true;
                b.just_fired = true;
                tempObj.GetComponent<Rigidbody2D>().gravityScale = 4;
            }
        }
    }
}
