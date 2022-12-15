using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_change : MonoBehaviour
{
    private float life;
    GameObject player;
    private int health;
    Vector3 cur_health;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<player_health>().health;
        life = health/3f;
        cur_health = this.gameObject.transform.localScale;
        this.gameObject.transform.localScale = new Vector3(life, cur_health.y, cur_health.z);
    }
}
