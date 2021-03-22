using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBarrier : MonoBehaviour
{
  public GameObject backBarrier;
  public PlayerMovement playerMovement;

  // If player collides with push barrier, push & back barrier will move right
    void OnTriggerStay2D(Collider2D other){
      if (Input.GetAxis("Horizontal") > 0 && other.CompareTag("Player")){
        transform.position += Vector3.right * playerMovement.horizontalMove * Time.deltaTime;
        backBarrier.transform.position += Vector3.right * playerMovement.horizontalMove * Time.deltaTime;
        
      }
    }

}
