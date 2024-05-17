using System;
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
	private bool _swipeRight;
	private bool _swipeLeft;
	private bool _swipeUp;
	private bool _swipeDown;

	private Vector2 _startTouchPosition;
	private Vector2 _endTouchPosition;

	[SerializeField] private GameObject _playerModel;
	private Rigidbody _rb;
	private Animator _animator;
	public event Action OnDeath;

	public float BoundXMax { get { return _boundXMax;}}
	public float BoundXMin { get { return _boundXMin;}}

	// Update is called once per frame
	void Start() {
		_rb = _playerModel.GetComponent<Rigidbody>();
		_animator = _playerModel.GetComponent<Animator>();
	}
	void Update () {

		// get the minimum boundary on z-axis
		float _boundZMin = _borderZMin.transform.position.z;

		if (Input.GetButtonDown("Left") || Input.GetButtonDown("Right") || Input.GetButtonDown("Up") || Input.GetButtonDown("Down")) {
			if (_perc == 1) {
				_lerpTime = 1;
				_currentLerpTime = 0;
				_isFirstInput = true;
				_isJumping = true;
				_rb.AddForce(0, 200, 0);
			}
		}

		// changing player's position
		_startPos = gameObject.transform.position;

		if (Input.GetButtonDown("Left") 
		&& gameObject.transform.position == _nextPos && gameObject.transform.position.x > _boundXMin) {
			_rb.AddForce(0, 20, 0);
			_nextPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
			gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
		}

		if (Input.GetButtonDown("Right") && gameObject.transform.position == _nextPos && gameObject.transform.position.x < _boundXMax) {
			_rb.AddForce(0, 20, 0);
			_nextPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
			gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
		}

		if (Input.GetButtonDown("Up") && gameObject.transform.position == _nextPos) {
			_rb.AddForce(0, 20, 0);
			_nextPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
			gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		if (Input.GetButtonDown("Down") && gameObject.transform.position == _nextPos && gameObject.transform.position.z > _boundZMin) {
			_rb.AddForce(0, 20, 0);
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

		if (_playerModel.transform.position.y < -3) {
			OnDeath?.Invoke();
			gameObject.SetActive(false);
		}

		_animator.SetBool("Jump", _isJumping);
	}



}
