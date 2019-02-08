using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Vector3 startinPosition;
    Vector3 startRotation;
    [SerializeField]
    GameObject parentTower;
    // Start is called before the first frame update
    void Start()
    {

        startinPosition = transform.position;
        startRotation = transform.rotation.eulerAngles;
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
        //gameObject.transform.position = startinPosition;
        if(parentTower != null)
        {
            //gameObject.transform.position = transform.GetComponentInParent<Transform>().transform.position;
            gameObject.transform.position = new Vector3 ( 4f, parentTower.transform.position.y,8.62f);
        }
       
        gameObject.transform.Rotate(startRotation.x,startRotation.y,startRotation.z);
    }
}
