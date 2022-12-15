using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class possum_movement : MonoBehaviour
{
    private float starting_x;
    public int isRight;
    public int walk_radius;
    public float speed = .1f;
    possum_animation p_anim;
    // Start is called before the first frame update
    void Start()
    {
        p_anim = this.gameObject.GetComponent<possum_animation>();
        starting_x = this.gameObject.transform.position.x;
        isRight = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(starting_x - this.gameObject.transform.position.x > walk_radius && isRight == -1)
        {
            isRight *= -1;
            Flip();
        }
        if(starting_x - this.gameObject.transform.position.x < -1*walk_radius && isRight == 1)
        {
            isRight *= -1;
            Flip();
        }
        if(p_anim.alive)
        {
            Vector3 temp = this.gameObject.transform.position;
            temp.x += isRight*speed;
            this.gameObject.transform.position = temp;
        }
    }

    private void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
