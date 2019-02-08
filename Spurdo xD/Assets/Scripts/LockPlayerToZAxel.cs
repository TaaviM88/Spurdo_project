using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPlayerToZAxel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.z = Mathf.Clamp(pos.z, 12.83f, 12.84f);
        //pos.y = Mathf.Clamp(0.07f, pos.y, 0.093f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
