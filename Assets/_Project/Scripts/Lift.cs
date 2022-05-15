using System;
using UnityEngine;

public class Lift : MonoBehaviour
{
	[SerializeField] private Transform min;
	[SerializeField] private Transform max;

	[SerializeField] private float maxDistanceDelta;
	
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftShift))
		{
			Up();
		}
		
		else if (Input.GetKey(KeyCode.LeftControl))
		{
			Down();
		}
	}

	private void Down()
	{
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, min.localPosition, maxDistanceDelta);
	}

	private void Up()
	{
		transform.localPosition = Vector3.MoveTowards(transform.localPosition, max.localPosition, maxDistanceDelta);
	}
}
