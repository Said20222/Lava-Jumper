using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour 
{
    public void Despawn()
    {
        gameObject.SetActive(false);
    }

    public GameObject Spawn()
    {
        gameObject.SetActive(true);
        return gameObject;
    }
}
