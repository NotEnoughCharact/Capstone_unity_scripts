using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_health_change : MonoBehaviour
{
   private float life;
    GameObject boss;
    private int health;
    Vector3 cur_health;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("boss_frog");
    }

    // Update is called once per frame
    void Update()
    {
        health = boss.GetComponent<boss_health>().health;
        life = health/20f;
        cur_health = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector3(life, cur_health.y, cur_health.z);
    }
}
