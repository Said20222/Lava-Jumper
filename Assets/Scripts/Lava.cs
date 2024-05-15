using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    void OnTriggerEnter (Collider collision) {
        //if (collision.gameObject.GetComponent<PlayerMovement>()) {
            Debug.Log("Stepped in lava");
            collision.gameObject.SetActive(false);
        //}
    }
}
