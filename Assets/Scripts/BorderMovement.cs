using System.Collections.Generic;
using UnityEngine;

public class BorderMovement : MonoBehaviour
{
    [SerializeField] private List<GameObject> _borders;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < _player.transform.position.z - distanceToPlayer) {
            Vector3 positionToPlayer = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z - 5);
            Vector3 nextPos = Vector3.Lerp(gameObject.transform.position, positionToPlayer, Time.deltaTime);
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, nextPos.z);
        }
    }
}
