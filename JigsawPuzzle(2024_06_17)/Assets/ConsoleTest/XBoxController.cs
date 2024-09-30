using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x != 0)
        {
            // Debug.Log("Horizontal : " + x);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Çª½¹Çª½¹");
        }
    }
}
