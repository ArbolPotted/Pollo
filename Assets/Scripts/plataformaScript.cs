using UnityEngine;
using System.Collections;

public class plataformaScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) { //Cuando el objeto entra en el collider
		Debug.Log ("Entrando");
		}
	void OnTriggerExit2D(Collider2D other) { //Cuando el objeto sale del collider
		Debug.Log ("Saliendo");
	}
	void OnTriggerStay2D(Collider2D other) { //Mientras el objeto este dentro del collider
		Debug.Log ("Dentro");
	}

}
