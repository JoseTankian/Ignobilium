using UnityEngine;
using System.Collections;

public class scriptGimnasta : MonoBehaviour {

	Animator animgimnasta;
	public Transform player;
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	private bool me_sigue = false;
	private bool dentro = false;

	public enum Estados {quieto, siguiendo, pirueta, transcendiendo};
	public Estados estado; 

	public Transform punto_arbol;
	public bool gimnasta_volteando = false;
	
	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		posicion = lerpinicial;
		animgimnasta = GetComponent<Animator> ();
	}
	void Update () 
	{
		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animgimnasta.SetBool("siguiendo",false);
			break;
			
		case Estados.siguiendo:
			animgimnasta.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;
			
		case Estados.pirueta:
			animgimnasta.SetBool("pirueta", true);
			Debug.Log ("HACIENDO PIRUETA");
			transform.position = Vector3.Lerp (transform.position, punto_arbol.position, posicion);
			break;
			
		case Estados.transcendiendo:
			
			
			break;
			
		default :
			//Debug.Log ("...");
			break;
		}
		
		if (dentro) {
			
			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue) {
				//me_sigue = true;
				UnFantasmaMas ();
				
				//	Debug.Log ("Funciona");
			} else if (Input.GetKey (KeyCode.A) && me_sigue) {
				//me_sigue = false;
				posicion = lerpinicial;
				UnFantasmaMenos ();
				
			} else if (Input.GetKey (KeyCode.D)) {
				//Bocadillo.SetActive(true);
				//dialogo.text ="ejemplo";
			}
		}
		
		if (me_sigue) {
			
			estado = Estados.siguiendo;
			
		} else if (!me_sigue) {
			
			
		}
		
		/*
			if(Input.GetKey(KeyCode.A))
			{
				me_sigue = !me_sigue;
			}
			*/
	}
	
	void UnFantasmaMas(){
		GameControl.fantasmaTeSigue = true;
		me_sigue = true;
	}
	
	void UnFantasmaMenos(){
		GameControl.fantasmaTeSigue = false;
		estado = Estados.quieto;
		me_sigue = false;
	}
	
	
	public void SetDentro(bool seg) {
		dentro = seg;
	}
	
	public void haciendoPirueta() {
		if (!me_sigue) {
			estado = Estados.pirueta;
		//	animgimnasta.SetBool("pirueta", true);
		}
	}
	
	public void transcendiendo(){
		estado = Estados.transcendiendo;
		animgimnasta.SetBool("transcendiendo",true);
	}
	
	public void destroy(){
		Destroy (gameObject);
	}
}