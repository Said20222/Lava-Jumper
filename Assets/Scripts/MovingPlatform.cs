using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _maxVal = 4;
    private float _minVal = -4;
    private int direction;
    private Vector3 _targetPosition;

    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    void Start() {
        direction = 1;
    }

    void Update() {

        if (direction > 0) {
            _targetPosition = new Vector3(_maxVal, transform.position.y, transform.position.z);
        } else {
            _targetPosition = new Vector3(_minVal, transform.position.y, transform.position.z);
        }

        // Calculate the movement direction
        Vector3 movementDirection = (_targetPosition - transform.position).normalized;

        // Move the platform at a constant speed
        gameObject.transform.position += movementDirection * _speed * Time.deltaTime;

        float distance = (_targetPosition - transform.position).magnitude;

        if (distance <= 0.1) {
            direction *= -1;
        }

    }

}
