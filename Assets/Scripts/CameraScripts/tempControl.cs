using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempControl : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f ,0.0f);
        transform.position += movement * speed * Time.deltaTime;
    }
}
