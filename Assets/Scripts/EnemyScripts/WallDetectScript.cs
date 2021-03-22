using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetectScript : MonoBehaviour
{
  public Enemy goomba;
    //switch right bool to its opposite in the goomba script to change directions
    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "Barrier" || other.gameObject.tag == "Player"){
        goomba.right = !goomba.right;
      }
    }
}
