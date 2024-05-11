using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private GameObject _regularPrefab;
    [SerializeField] private GameObject _brokenPrefab;

    void OnCollisionEnter() {
        if (_regularPrefab.activeSelf) {
            _regularPrefab.SetActive(false);
            _brokenPrefab.SetActive(true);
        } else {
            _regularPrefab.SetActive(false);
        }
    }

    void OnEnable() {

    }

    void OnDisable() {
        
    }
}
