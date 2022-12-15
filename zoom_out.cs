using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_out : MonoBehaviour
{
    public bool happened;
    Vector3 cur_pos;
    GameObject b_health;
    // Start is called before the first frame update
    void Start()
    {
        b_health = GameObject.Find("boss_health");
        b_health.SetActive(false);
        happened = false;
        cur_pos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cur_pos = this.gameObject.transform.position;
        if(cur_pos.x > 582 && cur_pos.y < 46 && !happened)
        {
            b_health.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = 20f;
            GameObject.Find("back").transform.localScale = new Vector3(.921108f, 1.477586f, 1f);
            happened = true;
        }
        
    }
}
