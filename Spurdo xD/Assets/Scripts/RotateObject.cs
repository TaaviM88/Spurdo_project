using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float horizontalMove = 0f;
    public float rotateSpeed = 40f;
    public bool isEnemy = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * rotateSpeed;

        if(!isEnemy)
        {
            transform.Rotate(Vector3.up, horizontalMove);
        }
        else
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
        
        
    }
}
