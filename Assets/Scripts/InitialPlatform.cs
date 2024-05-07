using UnityEngine;

public class InitialPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        if (_player.transform.position.z > 15) {
            Destroy(gameObject);
        }
    }
}
