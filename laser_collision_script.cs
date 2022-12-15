using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_collision_script : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag != "fireball")
        {
            Destroy(this.gameObject);
        }
    }
}
