using UnityEngine;

public class WheelDrive : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _torque = 1;
	
	private const float _maxAngularVelocity = 10;
	
	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			Forward();
		}

		if (Input.GetKey(KeyCode.S))
		{
			Backward();
		}

		if (Input.GetKey(KeyCode.Space))
		{
			Brake();
		}
	}

	private void Brake()
	{
		_rigidbody.angularVelocity = Vector3.zero;
		_rigidbody.freezeRotation = true;
	}

	private void Forward()
	{
		Rotate(1);
	}

	private void Backward()
	{
		Rotate(-1);
	}

	private void Rotate(float direction)
	{
		_rigidbody.freezeRotation = false;
		
		if (_rigidbody.angularVelocity.z is > -_maxAngularVelocity and < _maxAngularVelocity)
		{
			_rigidbody.AddRelativeTorque(0, direction * _torque, 0, ForceMode.Force);
		}
		
	}
}
