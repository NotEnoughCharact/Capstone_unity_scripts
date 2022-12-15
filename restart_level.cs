using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart_level : MonoBehaviour
{
    public Vector3 respawn_point;
    private int total_deaths = 0;
    public int starting_score = 0;
    private GameObject[] all_objs;
    // Start is called before the first frame update
    void Start()
    {
        respawn_point = this.gameObject.transform.position;
        all_objs = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<player_health>().health == 0)
        {
            total_deaths++;
            GameObject.Find("player").GetComponent<Spawner>().has_power = false;
            GameObject.Find("score_text").GetComponent<get_score>().attempts++;
            this.gameObject.GetComponent<player_health>().health = 3;
            this.gameObject.GetComponent<player_score>().score = starting_score;
            this.gameObject.transform.position = respawn_point;
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 8.14131f;
            GameObject.Find("player").GetComponent<zoom_out>().happened = false;
            GameObject.Find("back").transform.localScale = new Vector3(.3752104f, .6023493f, 1f);
            foreach (GameObject i in all_objs)
            {
                if(i.tag == "bird")
                {
                    i.transform.position = i.GetComponent<bird_movement>().startPos;
                    i.GetComponent<bird_movement>().started = false;
                    i.GetComponent<bird_movement>().alive = true;
                    i.GetComponent<bird_animation>().counter = 0;
                    i.GetComponent<bird_animation>().bird_ind = 0;
                    i.GetComponent<bird_animation>().alive = true;
                }
                else if(i.tag == "possum")
                {
                    i.GetComponent<possum_health>().health = 3;
                    i.GetComponent<possum_health>().alive = true;
                    i.GetComponent<possum_animation>().possum_ind = 0;
                    i.GetComponent<possum_animation>().counter = 0;
                    i.GetComponent<possum_animation>().color_counter = 0;
                    i.GetComponent<possum_animation>().alive = true;
                }
                else if(i.tag == "cherry")
                {
                    i.GetComponent<cherry>().cherry_ind = 0;
                    i.GetComponent<cherry>().counter = 0;
                    i.GetComponent<cherry>().is_aquired = false;
                }
                else if(i.tag == "jewel")
                {
                    i.GetComponent<jewel>().jewel_ind = 0;
                    i.GetComponent<jewel>().counter = 0;
                    i.GetComponent<jewel>().is_aquired = false;
                }
                else if(i.tag == "frog")
                {
                    i.GetComponent<frog_health>().health = 2;
                    i.GetComponent<frog_health>().alive = true;
                    i.GetComponent<frog_animation>().frog_idle_ind = 0;
                    i.GetComponent<frog_animation>().counter = 0;
                    i.GetComponent<frog_animation>().color_counter = 0;
                    i.GetComponent<frog_animation>().alive = true;
                    i.GetComponent<frog_animation>().upwards = false;
                    i.GetComponent<frog_animation>().grounded = true;
                    i.GetComponent<frog_animation>().idle = true;
                    i.GetComponent<frog_movement>().moving = false;
                    i.transform.position = i.GetComponent<frog_movement>().startPos;
                }
                else if(i.tag == "boss")
                {
                    i.GetComponent<boss_health>().health = 20;
                    i.GetComponent<boss_animation>().counter = 0;
                    i.GetComponent<boss_animation>().frog_idle_ind = 0;
                    i.GetComponent<boss_animation>().started = false;
                }
                i.SetActive(true);
                
            }
            GameObject.Find("boss_health").SetActive(false);
        }
    }
}
