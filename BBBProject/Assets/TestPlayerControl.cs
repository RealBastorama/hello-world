using UnityEngine;
using System.Collections;

public class TestPlayerControl : MonoBehaviour {
	Animation animationComponent;

	// Use this for initialization
	void Start () {
		animationComponent = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			Debug.Log ("Fire1");
			animationComponent.Play("VB_Walk");
		}
		else
		{
			animationComponent.Play("VB_Idle");
		}
	}
}
