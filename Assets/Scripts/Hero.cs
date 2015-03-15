using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Hero : MonoBehaviour {

	private Rigidbody2D body;
	private const float MAX_ANGULAR_VEL = - 1400;

	void Awake () 
	{
		body = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	void Update () 
	{
		body.AddTorque (MAX_ANGULAR_VEL/10);
		if (body.angularVelocity < MAX_ANGULAR_VEL) 
		{
			body.angularVelocity = MAX_ANGULAR_VEL;
		}
	}

}
