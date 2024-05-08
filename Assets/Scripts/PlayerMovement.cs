using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Vector3 _nextPos;
	private Vector3 _startPos;
	[SerializeField] private float _speed;
	[SerializeField] private float _boundXMin;
	[SerializeField] private float _boundXMax;
	[SerializeField] private GameObject _borderZMin;
	private float _lerpTime;
	private float _currentLerpTime;
	private float _perc = 1;

	private bool _isFirstInput;
	private bool _isJumping;

	//[SerializeField] private Rigidbody _rb;
	[SerializeField] private Animator _animator;

	// Update is called once per frame
	void Update () {

		// get the minimum boundary on z-axis
		float _boundZMin = _borderZMin.transform.position.z;

		if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Up") || Input.GetButtonDown("Down")) {
			if (_perc == 1) {
				_lerpTime = 1;
				_currentLerpTime = 0;
				_isFirstInput = true;
				_isJumping = true;
			}
		}

		// changing player's position
		_startPos = gameObject.transform.position;

		if (Input.GetButtonDown("Left") && gameObject.transform.position == _nextPos && gameObject.transform.position.x > _boundXMin) {
			_nextPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
			gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
		}

		if (Input.GetButtonDown("Right") && gameObject.transform.position == _nextPos && gameObject.transform.position.x < _boundXMax) {
			_nextPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
		}

		if (Input.GetButtonDown("Up") && gameObject.transform.position == _nextPos) {
			_nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		if (Input.GetButtonDown("Down") && gameObject.transform.position == _nextPos && gameObject.transform.position.z > _boundZMin) {
			_nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
			gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
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

}
