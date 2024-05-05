using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private Camera _camera;
    RaycastHit hit;
    private int _surfaceType = 1;
    private int _surfaceLength;
    private int _playerDistance = 12;
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private Queue<GameObject> _rockPool = new Queue<GameObject>();
    private Queue<GameObject> _lavaPool = new Queue<GameObject>();

    void Start()
    {
        // Initialize object pools
        InitializeObjectPool(_rockPrefab, _rockPool);
        InitializeObjectPool(_lavaPrefab, _lavaPool);
    }
    void Update()
    {
        Vector3 targetPosition = 4 * Vector3.forward + Vector3.down;
        Vector3 playerPosition = _camera.transform.position;

        if (Physics.Raycast(_camera.transform.position, targetPosition, out hit)) {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            Debug.Log("Hit");
        } else {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            Debug.Log("Did not hit");
            if (_surfaceType == 0) {
                //_surfaceLength = Random.Range(3, 5);
                _surfaceLength = 5;
                for (int i = 0; i < _surfaceLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _playerDistance += 1;
                    //GameObject rockInstance = Instantiate(_rockPrefab) as GameObject;
                    GameObject rockInstance = GetPooledObject(_rockPrefab, _rockPool);
                    rockInstance.transform.position = initialPosition;
                    rockInstance.SetActive(true);
                    _surfaceType = 1;
                }
            } else if (_surfaceType == 1) {
                //_surfaceLength = Random.Range(10, 15);
                _surfaceLength = 15;
                for (int i = 0; i < _surfaceLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _playerDistance += 1;
                    //GameObject lavaInstance = Instantiate(_lavaPrefab) as GameObject;
                    GameObject lavaInstance = GetPooledObject(_lavaPrefab, _lavaPool);
                    lavaInstance.transform.position = initialPosition;
                    lavaInstance.SetActive(true);
                    _surfaceType = 0;
                }
            }
        }

        ReturnObjectsIfPassed();
    }

    void ReturnObjectsIfPassed()
    {
        // Get the position of the player character
        Vector3 playerPosition = _camera.transform.position;

        // Iterate through active objects in the scene
        foreach (GameObject rockInstance in _rockPool)
        {
            if (rockInstance.activeSelf && rockInstance.transform.position.z < playerPosition.z - 5)
            {
                ReturnToPool(rockInstance, _rockPool);
            }
        }

        foreach (GameObject lavaInstance in _lavaPool)
        {
            if (lavaInstance.activeSelf && lavaInstance.transform.position.z < playerPosition.z - 5)
            {
                ReturnToPool(lavaInstance, _lavaPool);
            }
        }
    }
    
    private void InitializeObjectPool(GameObject prefab, Queue<GameObject> pool)
    {
        // pre-instantiate all prefabs in a pool
        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    private GameObject GetPooledObject(GameObject prefab, Queue<GameObject> pool)
    {
        // Retrieve an object from the pool, or instantiate a new one if pool is empty
        if (pool.Count > 0)
        {
            GameObject obj = pool.Peek();
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab); 
            pool.Enqueue(obj);
            return obj;
        }
    }

    private void ReturnToPool(GameObject obj, Queue<GameObject> pool)
    {
        // Deactivate the object in the pool
        obj.SetActive(false);
        //pool.Enqueue(obj);
    }
}


