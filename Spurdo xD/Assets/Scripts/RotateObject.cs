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
            playerPositionY = GameManager.Instance.player.transform.position.y;
            if((transform.position.y + 40 ) < (playerPositionY ))
            {
                transform.position = new Vector3(0, playerPositionY, 0);
            }
            
        }
        else
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
        
      
    }
}
