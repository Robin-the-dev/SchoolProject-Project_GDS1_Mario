using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private Collider2D backBarrier;
  private Collider2D goomba;
  //public Collider2D koopaPrefab;
  public bool right;
  public float speed;

  //Enemies can walk through the backbarrier
  void Start()
  {
    right = false;
    backBarrier = GameObject.FindWithTag("BackBarrier").GetComponent<BoxCollider2D>();
    goomba = GetComponent<BoxCollider2D>();
    Physics2D.IgnoreCollision(goomba, backBarrier, true);
    //Physics2D.IgnoreCollision(koopaPrefab, backBarrier, true);
  }

  //Will auto move to left or right if it hits a barrier (See WallDetectScript)
  void FixedUpdate()
  {
    if (!right)
      transform.position += Vector3.left * speed * Time.deltaTime;
    else
      transform.position += Vector3.right * speed * Time.deltaTime;
  }

  //ignore collision between Goombas
  void OnTriggerEnter2D(Collider2D other){
    if (other.gameObject.tag == "Goomba"){
      Physics2D.IgnoreCollision(goomba, other, true);
    }
  }
}
