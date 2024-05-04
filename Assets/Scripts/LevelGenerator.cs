using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private Camera _camera;
    RaycastHit hit;
    private int _surfaceType = 1;
    private int _surfaceLength;
    private int _playerDistance = 5;
    private int _step = 0;
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    void Update()
    {
        // if (Input.GetButtonDown("Up")) {
        //     _step++;
        //     if (_surfaceType == 0) {
        //         _surfaceLength = Random.Range(3, 6);
        //         for (int i = 0; i < _surfaceLength; i++) {
        //             initialPosition = new Vector3(0, -0.5f, _playerDistance);
        //             _playerDistance += 1;
        //             GameObject rockInstance = Instantiate(_rockPrefab) as GameObject;
        //             rockInstance.transform.position = initialPosition;
        //             _surfaceType = 1;
        //         }
        //     } else if (_surfaceType == 1) {
        //         _surfaceLength = Random.Range(5, 15);
        //         for (int i = 0; i < _surfaceLength; i++) {
        //             initialPosition = new Vector3(0, -0.5f, _playerDistance);
        //             _playerDistance += 1;
        //             GameObject lavaInstance = Instantiate(_lavaPrefab) as GameObject;
        //             lavaInstance.transform.position = initialPosition;
        //             _surfaceType = 0;
        //         }
        //     }
        // }

        // if (Input.GetButtonDown("Down")) {
        //     _step--;
        // }

        Vector3 targetPosition = _camera.transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(_camera.transform.position, targetPosition, out hit)) {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            Debug.Log("Hit");
        } else {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            Debug.Log("Did not hit");
            if (_surfaceType == 0) {
                _surfaceLength = Random.Range(3, 6);
                for (int i = 0; i < _surfaceLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _playerDistance += 1;
                    GameObject rockInstance = Instantiate(_rockPrefab) as GameObject;
                    rockInstance.transform.position = initialPosition;
                    _surfaceType = 1;
                }
            } else if (_surfaceType == 1) {
                _surfaceLength = Random.Range(5, 15);
                for (int i = 0; i < _surfaceLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _playerDistance += 1;
                    GameObject lavaInstance = Instantiate(_lavaPrefab) as GameObject;
                    lavaInstance.transform.position = initialPosition;
                    _surfaceType = 0;
                }
            }
        }
    }
}


