using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
  public Transform target;
  private Vector3 offSet;
  //private Camera camera;

  //Calculate the offset between the back barrier and the camera position.
  void Start(){
    //camera = gameObject.GetComponent<Camera>();
    offSet = new Vector3( (transform.position.x - target.position.x), transform.position.y, transform.position.z);
  }
  //Move camera based on the back barriers position + the offset
  void LateUpdate(){
    transform.position = new Vector3((target.position.x + offSet.x) , transform.position.y, transform.position.z);
  }

}
