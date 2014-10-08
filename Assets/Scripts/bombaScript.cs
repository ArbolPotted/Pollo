using UnityEngine;
using System.Collections;

public class bombaScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log ("CHOQUE!!");
		//if (coll.gameObject.tag == "Enemy")
		//damage();
	}
}
