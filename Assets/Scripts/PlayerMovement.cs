using System.Globalization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Vector3 _nextPos;
	private Vector3 _startPos;
	[SerializeField] private float _jumpForce;
	[SerializeField] private float _speed;
	[SerializeField] private float _speedRot;
	private float _lerpTime;
	private float _currentLerpTime;
	private float _perc = 1;

	private bool _isFirstInput;
	private bool _isJumping;

	//[SerializeField] private Rigidbody _rb;
	[SerializeField] private Animator _animator;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Up") || Input.GetButtonDown("Down")) {
			if (_perc == 1) {
				_lerpTime = 1;
				_currentLerpTime = 0;
				_isFirstInput = true;
				_isJumping = true;
			}
		}

		_startPos = gameObject.transform.position;

		if (Input.GetButtonDown("Left") && gameObject.transform.position == _nextPos) {
			_nextPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
		}

		if (Input.GetButtonDown("Right") && gameObject.transform.position == _nextPos) {
			_nextPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
		}

		if (Input.GetButtonDown("Up") && gameObject.transform.position == _nextPos) {
			_nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
		}

		if (Input.GetButtonDown("Down") && gameObject.transform.position == _nextPos) {
			_nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
		}

		if (_isFirstInput == true) {
			_currentLerpTime += Time.deltaTime * _speed;
			_perc = _currentLerpTime / _lerpTime;
			gameObject.transform.position = Vector3.Lerp(_startPos, _nextPos, _perc);

			if (_perc > 0.8f) {
				_perc = 1;
			}
			if (Mathf.Round(_perc) == 1) {
				_isJumping = false;
			}
		}

		_animator.SetBool("Jump", _isJumping);
	}

	public bool IsJumping {
		get {return _isJumping;}
	}
}
