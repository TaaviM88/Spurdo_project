using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float horizontalMove = 0f;
    public float rotateSpeed = 40f;
    public bool isEnemy = false;
    public Joystick joystick;
    bool mobilebuild = false;
    //bool isEnemyActive = false;
    //TowerScript player;
    float playerPositionY;
    // Start is called before the first frame update
    void Start()
    {
        mobilebuild = GameManager.Instance.IsMobilebuild();
       
        if (!mobilebuild)
        {
            if(joystick == null)
            {
                return;
            }
        }
       /* if(isEnemy)
        {
            player = GetComponentInParent<TowerScript>();
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mobilebuild && !isEnemy)
        {
            horizontalMove = joystick.Horizontal * rotateSpeed;
        }
        else if (!mobilebuild && !isEnemy)
        {
            horizontalMove = Input.GetAxis("Horizontal") * rotateSpeed;
        }

        if(!isEnemy)
        {
            transform.Rotate(Vector3.up, horizontalMove);
        }
        else
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
        
       /* if(isEnemy)
        {
            if (transform.position.y < playerPositionY)
            {
                isEnemyActive = false;
            }
            else
                isEnemyActive = true;
        }*/
    }
}
