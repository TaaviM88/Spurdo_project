using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public GameObject player;
    public bool firstOne = false;
    public int towerIndex = 50;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*float y = transform.position.y;
        y -= player.transform.position.y;

        if(y <= -30)
        {
            RaiseTower();
        }*/

        //Debug.Log(y + " " + gameObject.name);
        if(player.transform.position.y > (transform.position.y + 30))
        {
            RaiseTower();
        }

        //Debug.Log(transform.position.y + " " + gameObject.name);
    }

    public float PlayerYPosition()
    {
        float y = player.transform.position.y;
        return y;
    }

    public void RaiseTower()
    {
       /*if (firstOne == true)
        {
            transform.Translate(new Vector3(transform.position.x, transform.position.y + 10, transform.position.z));
            firstOne = false;
        }*/
        //transform.Translate(new Vector3(transform.position.x, transform.position.y + towerIndex, transform.position.z));
        //transform.Translate(new Vector3(transform.position.x, transform.position.y +50, transform.position.z));
        transform.position = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
        transform.Rotate(new Vector3(0, transform.rotation.y + 180, 0));
        /*Transform[] childs = GetComponentsInChildren<Transform>();
        foreach (Transform child in childs)
        {

            child.transform.position += child.parent.transform.position; 
            //Debug.Log(child.name);
        }*/

    }
}
