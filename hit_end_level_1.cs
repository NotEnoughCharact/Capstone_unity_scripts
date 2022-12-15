using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_end_level_1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            this.gameObject.GetComponent<to_level_2>().hit = true;
        }
    }
}
