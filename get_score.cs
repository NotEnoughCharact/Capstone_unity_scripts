using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class get_score : MonoBehaviour
{
    GameObject player_obj;
    private int score;
    Text t_obj;
    public int attempts;
    void Start()
    {
        attempts = 0;
        player_obj = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        score = player_obj.GetComponent<player_score>().score;
        t_obj = this.gameObject.GetComponent<Text>();
        t_obj.text = "score: "+score.ToString()+"\nrespawns: "+attempts.ToString();
    }
}
