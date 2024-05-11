using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour 
{

    void OnCollisionEnter (Collision collision) {
        //if (collision.gameObject.GetComponent<PlayerMovement>()) {
            Debug.Log("Stepped on a platform");
        //}
    }
}
