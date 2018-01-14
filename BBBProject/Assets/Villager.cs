using UnityEngine;
using System.Collections;

public class Villager : MonoBehaviour {

	Animation m_playerAnimation;

	bool m_attacking;
	bool m_walking;
	bool m_locked;

	// Use this for initialization
	void Start () {
		m_playerAnimation = GetComponent<Animation>();
		m_attacking = false;
		m_walking = false;
		m_locked = true;
	}
	
	// Update is called once per frame
	void Update () {
		Animation playerAnimation;
		playerAnimation = GetComponent<Animation>();

		if(Input.GetButtonDown("Jump"))
		{
			m_attacking = true;
			playerAnimation.wrapMode = WrapMode.Once;
			//playerAnimation.Blend("VB_Attack00", 1.0f, 0.3f);
			playerAnimation.Play("VB_Attack00");
			Debug.Log("We Have Hit the Space Bar!");
		}
		if (m_attacking && !m_playerAnimation.GetComponent<Animation>().isPlaying)
		{
			playerAnimation.wrapMode = WrapMode.Loop;
			playerAnimation.Blend("VB_Idle", 1.0f, 1.0f );
			m_attacking = false;
			//playerAnimation.Play("VB_Idle");
		}

		float verticalAxis = Input.GetAxis("Vertical");
		float horizontalAxis = Input.GetAxis("Horizontal");
		if(Mathf.Abs(verticalAxis)> 0.5f)
		{
			if (verticalAxis> 0.5f)
			{
				if (!m_walking)
				{
					playerAnimation.wrapMode = WrapMode.Loop;
					playerAnimation.Play("VB_Walk");
					m_walking = true;
				}
			}
			else
			if(verticalAxis< -0.5f)
			{
				if ((!m_walking) && (m_locked))
				{
					playerAnimation.wrapMode = WrapMode.Loop;
					playerAnimation.Play("VB_B_Walk");
					m_walking = true;
				}
			}
		}
		else
		if (Mathf.Abs(horizontalAxis)> 0.5f)
		{
			if (horizontalAxis> 0.5f)
			{
				if (!m_walking)
				{
					playerAnimation.wrapMode = WrapMode.Loop;
					playerAnimation.Play("VB_L_Walk");
					m_walking = true;
				}
			}
			else
			if(horizontalAxis< -0.5f)
			{
				if (!m_walking)
				{
					playerAnimation.wrapMode = WrapMode.Loop;
					playerAnimation.Play("VB_R_Walk");
					m_walking = true;
				}
			}
		}
		else
		{
			if (m_walking)
			{
				playerAnimation.wrapMode = WrapMode.Loop;
				playerAnimation.Play("VB_Idle");
				m_walking = false;
			}
		}
		/*
		if (Input.GetAxis("Lock")> 0.5f)
		{
			m_locked = true;
		}
		else
		{
			m_locked = false;
		}*/
	}
}
