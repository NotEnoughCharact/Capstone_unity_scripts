using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class to_level_3 : MonoBehaviour
{
    public bool hit = false;
    Vector3 spawn_point = new Vector3(529f,66f,0f);
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if(hit)
        {
            hit = false;
            player.transform.position = spawn_point;
            player.GetComponent<player_health>().health = 3;
            player.GetComponent<Spawner>().has_power = false;
            player.GetComponent<restart_level>().respawn_point = spawn_point;
            player.GetComponent<restart_level>().starting_score = player.GetComponent<player_score>().score;
        }
    }
}
