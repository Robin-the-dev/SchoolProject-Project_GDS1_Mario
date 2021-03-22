using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTestSpriteController : MonoBehaviour
{
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        transform.Translate(inputX * speed * Time.deltaTime, inputY * speed * Time.deltaTime, 0);
    }
}
