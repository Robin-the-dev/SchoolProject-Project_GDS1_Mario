using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  //Kill gameobject if it touches a death barrier.
  void OnTriggerEnter2D(Collider2D other){
    try {
      if (other.gameObject.tag == "DeathBarrier" && other.GetComponent<Identify>().isBarrier){
        Destroy(gameObject);
      }
    }
    catch (System.NullReferenceException e) {
      Debug.Log("did not hit death barrier");
    }

  }

}
