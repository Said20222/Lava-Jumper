using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _lavaPrefab;
    [SerializeField] private GameObject _rockPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _lavaSectionLength;
    [SerializeField] private float _rockSectionLength;
    [SerializeField] private float _distanceUntillDestruction;
    RaycastHit hit;
    private int _surfaceType = 1;
    private int _playerDistance = 5;
    private Vector3 initialPosition = new Vector3(0, 0, 0);
    private Vector3 _platformPosition = new Vector3(0, 0.5f, 0);
    private Queue<GameObject> _rockPool = new Queue<GameObject>();
    private Queue<GameObject> _lavaPool = new Queue<GameObject>();
    private PlatformPooler _platformPool;

    void Start()
    {
        // Initialize object pools
        InitializeObjectPool(_rockPrefab, _rockPool);
        InitializeObjectPool(_lavaPrefab, _lavaPool);
        _platformPool = PlatformPooler.Instance;
    }
    void Update()
    {
        Vector3 targetPosition = 4 * Vector3.forward + Vector3.down;

        if (Physics.Raycast(_camera.transform.position, targetPosition, out hit)) {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            //Debug.Log("Hit");
        } else {
            Debug.DrawRay(_camera.transform.position, targetPosition);
            //Debug.Log("Did not hit");
            if (_surfaceType == 0) {
                for (int i = 0; i < _rockSectionLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _playerDistance++;
                    GameObject rockInstance = GetPooledObject(_rockPrefab, _rockPool);
                    rockInstance.transform.position = initialPosition;
                    rockInstance.SetActive(true);
                    _surfaceType = 1;
                }
            } else if (_surfaceType == 1) {
                for (int i = 0; i < _lavaSectionLength; i++) {
                    initialPosition = new Vector3(0, -0.5f, _playerDistance);
                    _platformPosition = new Vector3(Random.Range(-4, 4), 0.1f, _playerDistance);
                    _playerDistance++;
                    GameObject lavaInstance = GetPooledObject(_lavaPrefab, _lavaPool);
                    lavaInstance.transform.position = initialPosition;
                    lavaInstance.SetActive(true);
                    _surfaceType = 0;

                    /// TODO: Spawn different platforms
                    _platformPool.SpawnFromPool("Platform", _platformPosition, Quaternion.identity);
                }
            }
        }


        ReturnObjectsIfPassed(_camera.transform.position, _distanceUntillDestruction);
    }

    void ReturnObjectsIfPassed(Vector3 playerPosition, float distance)
    {
        // Iterate through active objects in the scene
        foreach (GameObject rockInstance in _rockPool)
        {
            if (rockInstance.activeSelf && rockInstance.transform.position.z < playerPosition.z - distance)
            {
                ReturnToPool(rockInstance);
            }
        }

        foreach (GameObject lavaInstance in _lavaPool)
        {
            if (lavaInstance.activeSelf && lavaInstance.transform.position.z < playerPosition.z - distance)
            {
                ReturnToPool(lavaInstance);
            }
        }
/// TODO: Returning platforms to their respective pools
        foreach (PlatformPooler.Pool pool in _platformPool.pools) {
            foreach (var poolEntry in _platformPool.poolDictionary) {
                //string platformName = poolEntry.Key;
                foreach (GameObject obj in poolEntry.Value) {
                    if (obj.activeSelf && obj.transform.position.z  < playerPosition.z - distance) {
                        obj.SetActive(false);
                    }
                }
            }
        }
    }
    
    private void InitializeObjectPool(GameObject prefab, Queue<GameObject> pool)
    {
        // pre-instantiate all prefabs in a pool
        for (int i = 0; i < 50; i++)
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
            GameObject obj = pool.Dequeue();
            pool.Enqueue(obj);
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(prefab); 
            obj.SetActive(false);
            return obj;
        }
    }

    private void ReturnToPool(GameObject obj)
    {
        // Deactivate the object and add it to the pool
        obj.SetActive(false);
    }
}


