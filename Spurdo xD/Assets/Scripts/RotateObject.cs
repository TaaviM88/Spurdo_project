using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float horizontalMove = 0f;
    public float rotateSpeed = 40f;
    public bool isEnemy = false;
    public Joystick joystick;
    public bool mobileBuild = false;
    // Start is called before the first frame update
    void Start()
    {
        if(!mobileBuild)
        {
            if(joystick == null)
            {
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(mobileBuild && !isEnemy)
        {
            horizontalMove = joystick.Horizontal * rotateSpeed;
        }
        else if (!mobileBuild && !isEnemy)
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
