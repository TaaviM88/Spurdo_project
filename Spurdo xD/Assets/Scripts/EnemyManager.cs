using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Vector3 startinPosition;
    // Start is called before the first frame update
    void Start()
    {

        startinPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            EnemyReset();
        }
    }

    private void EnemyReset()
    {
        gameObject.transform.position = startinPosition;
    }
}
