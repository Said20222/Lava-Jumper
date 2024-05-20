using UnityEngine;

public class InitialPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    void Update()
    {
        if (_player.transform.position.z > 15) {
            Destroy(gameObject);
        }
    }
}
