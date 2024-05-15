using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private GameObject _regularPrefab;
    [SerializeField] private GameObject _brokenPrefab;
    [SerializeField] private float _breakingTime;

    void OnCollisionEnter() {
        if (_regularPrefab.activeSelf) {
            Debug.Log("Breaking started");
            _regularPrefab.SetActive(false);
            _brokenPrefab.SetActive(true);
            StartCoroutine(BreakingCoroutine());
        } 
    }

    void OnEnable() {
         _regularPrefab.SetActive(true);
        _brokenPrefab.SetActive(false);
    }

    IEnumerator BreakingCoroutine() {
        yield return new WaitForSeconds(_breakingTime);
        gameObject.SetActive(false);
        Debug.Log("Breaking finished");
        yield return null;
    }
}
