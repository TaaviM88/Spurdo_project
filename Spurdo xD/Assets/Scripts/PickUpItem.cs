using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public int point = 1;
    public float respawnTimer = 20f;
    float countdown;
    // Start is called before the first frame update
    void Start()
    {
        if(!isActiveAndEnabled)
        {
            EnableObject(true);
        }
        //Tallennetaan haluttu timerin sekunttimäärä
        countdown = respawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isActiveAndEnabled)
        {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer <= 0.0f)
            {
                EnableObject(true);
                respawnTimer = countdown;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AddPoint();
            EnableObject(false);
            //Debug.Log("ES got");
        }
    }

    void AddPoint ()
    {
        Score.Instance.AddPoint(point);
    }

    void EnableObject(bool enable)
    {
        gameObject.SetActive(enable);
    }
}
