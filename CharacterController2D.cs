//base movement code made by someone else

//modifications made by Ryan Lehmer for Fall 2022 Chico state Capstone 

using UnityEngine;
using UnityEngine.Events;
using System.Text;
using System.IO;

public class CharacterController2D : MonoBehaviour
{
	
	[SerializeField] private bool m_AirControl = true;							// Whether or not a player can steer while jumping;
	[SerializeField] public LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;							// A position marking where to check for ceilings

	private float m_JumpCieling = 1200f;						// Max height of jump.
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private bool m_holding_jump = false;
	public float m_JumpForce = 60f;							// Amount of force added when the player jumps
	public SpriteRenderer spriteRenderer;
	public Sprite[] sprite_idle;
	public Sprite[] sprite_jump;
	public Sprite[] sprite_run;
	public Sprite[] sprite_hurt;
	private int sprite_run_ind = 0;
	private int run_counter = 0;
	private int sprite_idle_ind = 0;
	private int idle_counter = 0;
	private Vector2 v_temp;
    public bool has_power;
	public bool is_hurt;
	public int hurt_counter;
	public float temp_force;
	public bool jump;
	private Vector3 curPos;
	private Vector3 prevPos;
	private float move;
	private float move_y;
	public float rayDistance = 1.8f;
	public LayerMask IgnoreMe;
	private float speed = 15f;


	
	
	void ChangeSprite(Sprite temp)
    {
        spriteRenderer.sprite = temp; 
    }

	private void Awake()
	{
		curPos = this.gameObject.transform.position;
		prevPos = this.gameObject.transform.position;
		jump = false;
		has_power = false;
		is_hurt = false;
		v_temp = new Vector2(.01f,.8f);
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

	}

	private void FixedUpdate()
	{
		
		curPos = this.gameObject.transform.position;
		move = curPos.x-prevPos.x;
		move_y = curPos.y-prevPos.y;
		prevPos = this.gameObject.transform.position;
		Vector2 curLeft = new Vector2(curPos.x-.6f,curPos.y);
		Vector2 curRight = new Vector2(curPos.x+.6f,curPos.y);
		Ray2D ray = new Ray2D(curPos, new Vector2(0.0f,-0.16f));
		if (Physics2D.Raycast(ray.origin, ray.direction, rayDistance, ~IgnoreMe) || Physics2D.Raycast(curLeft, ray.direction, rayDistance, ~IgnoreMe) || Physics2D.Raycast(curRight, ray.direction, rayDistance, ~IgnoreMe))
        {
            // If the ray collides with an object, the object is touching the ground
			m_Grounded = true;
        }
        else
        {
            // If the ray does not collide with an object, the object is not touching the ground
			m_Grounded = false;
        }
		if (m_Grounded || m_AirControl)
		{
			float left_right = Input.GetAxis("Horizontal");
			float temp_y = m_Rigidbody2D.velocity.y;
			m_Rigidbody2D.velocity = new Vector2(left_right*speed, temp_y);
			if(is_hurt)
			{
				if(hurt_counter == 8)
					ChangeSprite(sprite_hurt[0]);
				else if(hurt_counter == 4)
					ChangeSprite(sprite_hurt[1]);
				else if(hurt_counter == 0)
				{
					is_hurt = false;
				}
				hurt_counter--;
			}

			if(move == 0 && m_Grounded)
			{
				if(idle_counter > 8)
				{
					sprite_idle_ind = (sprite_idle_ind+1)%4;
					if(!is_hurt)
						ChangeSprite(sprite_idle[sprite_idle_ind]);
					idle_counter = 0;
				}
				else
				{
					idle_counter++;
				}
			}
			if(move != 0 && m_Grounded)
			{
				if(run_counter > 4)
				{
					sprite_run_ind = (sprite_run_ind+1)%6;
					if(!is_hurt)
						ChangeSprite(sprite_run[sprite_run_ind]);
					run_counter = 0;
				}
				else
				{
					run_counter++;
				}
			}
				// If the input is moving the player right and the player is facing left...
			if (left_right > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (left_right < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		if(m_Grounded)
		{
			change_hit_box(-0.01f, 0.12f, -0.065f, 0.19f);
		}
		if(!jump)
		{
			m_holding_jump = false;
			temp_force = 0f;
		}
		if(!m_Grounded && m_holding_jump && temp_force > 1)
		{
			temp_force = temp_force/1.7f;
			m_Rigidbody2D.AddForce(new Vector2(0f, temp_force));
		}
		// If the player should jump...
		else if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			temp_force = m_JumpCieling/3;
			m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0f);
			m_Rigidbody2D.AddForce(new Vector2(0f, temp_force));
			m_holding_jump = true;
			if(!is_hurt)
				ChangeSprite(sprite_jump[0]);
			change_hit_box(0f, .12f, -0.03f, 0.15f);
		}
		else 
		{
			m_holding_jump = false;
			temp_force = 0f;
		}
		if(move_y < 0 && !m_Grounded)
		{
			if(!is_hurt)
				ChangeSprite(sprite_jump[1]);
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	private void change_hit_box(float off_x, float size_x, float off_y, float size_y)
	{
		Vector2 off = new Vector2(off_x, off_y);
		Vector2 size = new Vector2(size_x, size_y);
		this.gameObject.GetComponent<BoxCollider2D>().offset = off;
		this.gameObject.GetComponent<BoxCollider2D>().size = size;
	}
}