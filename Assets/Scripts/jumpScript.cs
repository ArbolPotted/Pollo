using UnityEngine;
using System.Collections;

public class jumpScript : MonoBehaviour {
	public int jumpForce = 200; //Fuerza de salto
	public int moveForce = 100; //Fuerza horizontal al mover
	public int maxSpeed = 50; //Velocidad maxima horizontal

	//public simpre antes que private
	//Audioclip para meter sonido
	public AudioClip sonidoVolar;
	public AudioClip sonidoHerido;
	public AudioClip sonidoCurado;

	public bool estaHerido = false; //Nueva variable para saber si pollo esta herido o no

	public void reiniciar (){
		Application.LoadLevel ("menu");
	}


	Animator animation; // Necesario para manejar las animaciones
	

	void Start () { //Al iniciar cargamos las variables de las animaciones
				animation = GetComponent <Animator> ();
		}

	
	void Update () {
				if (Input.GetButtonDown ("Jump")) //Cuando pulsamos espacio salta
						saltar (); // Mas abajo la funcion explicada
										
				if (Input.GetKey ("a")) {
						mover (moveForce * -1); //Multiplicamos negativo para ir a la izq.
			transform.localScale = new Vector3(-1,1,1); //Para cambiar la direccion del polllo
				}	

				if (Input.GetKey ("d")) {
						mover (moveForce);
			transform.localScale = new Vector3(1,1,1);
				}
	
		}
	/*Funcion Saltar
	 * Esta funcion aplica una fuerza hacia arriba deifinida por jumpForce
	 * TODO: Falta animacion de salto y sonido
	 */

void saltar(){ 
		if(!estaHerido) //la exclamacion es lo contrario de lo que pongamos a estaHerido
    //Aplicamos una fuerza con rigidbody2D.AddForce
	rigidbody2D.AddForce(new Vector2(0,jumpForce));
	//New Vector2(0,jumpforce) es un vector con la X a cero y la Y a jumpForce
			animation.SetBool ("Fly", true);
		AudioSource.PlayClipAtPoint (sonidoVolar, transform.position); //incluir ese sonido para la accion, transform.position puede cambiar donde oimos el sonido
		}

	void damage(){
		estaHerido = true;
		animation.SetBool ("Damage", true); //En esta funcion le podemos meter vida dejandolo separado
		AudioSource.PlayClipAtPoint (sonidoHerido, transform.position);
		}

	void curaHat (){ //para curar al pollo
		estaHerido = false;
		animation.SetBool ("Damage", false);
		AudioSource.PlayClipAtPoint (sonidoCurado, transform.position);
	}

	void OnCollisionEnter2D(Collision2D coll){
				animation.SetBool ("Fly", false); //Cuando choca con otro collider para de volar
				if (coll.gameObject.tag == "Enemy")
						damage ();
		if (coll.gameObject.tag == "Curar") //Cuando tocamos sombrero se produce curar al pollo
						curaHat ();
		if ((estaHerido == true) & (coll.gameObject.tag == "Enemy") || (coll.gameObject.tag == "abismo"))
						reiniciar ();

		}

		

	/*Funcion Mover
	 * Parametros: fuerza-> Fuerza que le vamos a aplicar para mover
	 * Aplicmaos una fuerza horizontal teniendo en cuenta no sobrepasar la velocidad maxima
	 */
	void mover (int fuerza) {
		// Creamos una variable para guardar la velocidad actual
				float velocity = rigidbody2D.velocity.x;
		//Para cuando cambia de direccion del pollo cambia velocidad a cero, mejora el movimiento
		if ((fuerza > 0 & velocity < 0) || (fuerza < 0 & velocity > 0))
						rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
		if(Mathf.Abs(velocity) < maxSpeed) //este if aplica la velocidad al pollo
				rigidbody2D.AddForce(new Vector2(fuerza,0));
		}

}
