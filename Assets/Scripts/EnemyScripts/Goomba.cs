using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour
{
  //if player hits the HeadHitDetect gameobject attached to the enemy he will delete the whole enemy gameobject.
  public GameObject goomba;
    void OnTriggerEnter2D(Collider2D other){
      if (other.CompareTag("Player"))
      {
          AudioManager.Instance.PlayStomp();
          Destroy(goomba);
      }
    }

}
