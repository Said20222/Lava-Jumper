using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        Vector3 positionToPlayer = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z - 4);
        Vector3 nextPos = Vector3.Lerp(gameObject.transform.position, positionToPlayer, Time.deltaTime);
        gameObject.transform.position = new Vector3(nextPos.x, transform.position.y, nextPos.z);
    }
}
