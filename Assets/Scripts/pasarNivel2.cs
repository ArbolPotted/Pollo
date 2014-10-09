using UnityEngine;
using System.Collections;

public class pasarNivel2 : MonoBehaviour {
	public string level = "proyecto";


	void OnTriggerEnter2D(Collider2D other){
		if(other.transform.tag == "Player") 
			Application.LoadLevel (level);
		}

	}
