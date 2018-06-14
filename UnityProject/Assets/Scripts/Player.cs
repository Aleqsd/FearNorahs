using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	
	public static bool instance = false;

	void Awake() {

	  if(instance)
		DestroyImmediate(gameObject);

	  instance = true;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
