using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    GameObject person;

    GameObject mainCamera;

    // Use this for initialization
    void Start () {

        person = GameObject.Find("Person");

        mainCamera = GameObject.Find("Main Camera");

    }
	
	// Update is called once per frame
	void Update () {
       
        mainCamera.transform.position = new Vector3(0,person.transform.position.y+3,-10);
       
    }
}
