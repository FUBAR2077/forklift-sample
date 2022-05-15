using UnityEngine;

public class WheelSteering : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Transform _maxLeft;
	[SerializeField] private Transform _maxRight;
	[SerializeField] private Transform _defaultRotation;
	
	[SerializeField] private float _torque = 1;
	
	private const float _maxAngularVelocity = 10;
	
	private void Update()
	{
		if (Input.GetKey(KeyCode.D))
		{
			Left();
		}
		else if (Input.GetKey(KeyCode.A))
		{
			Right();
		}
		else
		{
			Forward();
		}
	}

	private void Forward()
	{
		Rotate(0);
	}

	private void Left()
	{
		Rotate(1);
	}

	private void Right()
	{
		Rotate(-1);
	}

	private void Rotate(float direction)
	{
		Transform target = direction == 0 ? _defaultRotation :
														direction > 0 ? _maxLeft :
														_maxRight;
		
		_rigidbody.rotation = Quaternion.RotateTowards(_rigidbody.rotation, target.rotation, 1);
	}
}
