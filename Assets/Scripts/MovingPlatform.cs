using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private float _speed;

    public float Speed {
        get { return _speed; }
        set { _speed = value; }
    }

    void Update() {

    }
}
