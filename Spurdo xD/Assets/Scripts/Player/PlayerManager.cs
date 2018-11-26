using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    bool reduceTimeScale = false;
    public float bulletTime = 2;
    float countdown = 0;
     float slowTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        countdown = bulletTime;
        reduceTimeScale = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            PlayerDie();
        }

        /*if(reduceTimeScale)
        {
            
            if(Time.timeScale > slowTime)
            {
                Time.timeScale -= Time.deltaTime;
            }
        }*/
       // Debug.Log("TimeScale: " + Time.timeScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") || collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            PlayerDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            reduceTimeScale = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            reduceTimeScale = false;
            Time.timeScale = 1;
        }
    }
    void PlayerDie()
    {
        Score.Instance.UpdateHighScore();
        GameManager.Instance.ResetScene();
    }


}
