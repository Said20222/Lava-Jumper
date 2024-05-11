using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private float _speed;
    private float _maxVal = 4;
    private float _minVal = -4;
    private Vector3 _targetPosition;

    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    void Start() {
        //_maxVal = 4;
        //_minVal = -4;
    }

    void Update() {
        if (_speed > 0) {
            float pingPongValue = Mathf.PingPong(Time.time, _maxVal - _minVal);
            float adjustedXCoordinate = pingPongValue + _minVal;
            _targetPosition = new Vector3(adjustedXCoordinate, gameObject.transform.position.y, gameObject.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter() {

    }
}
