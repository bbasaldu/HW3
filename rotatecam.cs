using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecam : MonoBehaviour
{

    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, -(speed * Time.deltaTime), 0);
        }

    }
}
