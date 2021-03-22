using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

  public int lives;
  private Vector3 initialPos;
  private Vector3 initialBackBarrierPos;
  private Vector3 initialPushBarrierPos;
  public GameObject backBarrier;
  public GameObject pushBarrier;
  private GameObject[] enemyPrefabs;


  void Start() {
    initialPos = transform.position;
    initialBackBarrierPos = backBarrier.transform.position;
    initialPushBarrierPos = pushBarrier.transform.position;
  }
  //death/collison script
  void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.tag == "DeathBarrier" && lives <= 0){
      //Death animation
      //
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    else if (other.gameObject.tag == "DeathBarrier" && lives >= 1){
      lives--;
      backBarrier.transform.position = initialBackBarrierPos;
      pushBarrier.transform.position = initialPushBarrierPos;
      transform.position = initialPos;
      enemyPrefabs = GameObject.FindGameObjectsWithTag("Goomba");
      foreach (GameObject e in enemyPrefabs){
        Destroy(e);
      }
    }
  }
}
