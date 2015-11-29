using UnityEngine;
using System.Collections;

public class scriptGordo : MonoBehaviour {

	Animator animgordo;
	public Transform player;
	public float speed = 1;
	public float lerpinicial = 0;
	private float posicion;
	private float distancia;
	private bool me_sigue = false;
	//	public Text dialogo;
	//	public GameObject Bocadillo;
	private bool dentro = false;
	// Use this for initialization
	public enum Estados {quieto, siguiendo, huyendo_boton, escuchando, llorando, transcendiendo};
	public Estados estado; 
	bool regandofinal = false;
	public Transform punto_boton;
	public Transform punto_origen;
	public bool gordorayado = false;
	
	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		posicion = lerpinicial;
		animgordo = GetComponent<Animator> ();}
	void Update () 
	{
		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animgordo.SetBool("siguiendo",false);
			break;
			
		case Estados.siguiendo:
			animgordo.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;

		case Estados.escuchando:
			animgordo.SetBool("siguiendo", false);
			if (!gordorayado) {
				Invoke ("regresoPosicion", 2);
			}
			
			break;

		case Estados.huyendo_boton:
			animgordo.SetBool("huyendo", true);
			transform.position = Vector3.Lerp (transform.position, punto_origen.position, posicion);
			Invoke ("QuietoAgain", 2);

			break;

		case Estados.llorando:
			animgordo.SetBool("llorando", true);
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
				if(gordorayado){
					me_sigue = false;
					estado = Estados.escuchando;
					UnFantasmaMenos ();
				} else if(!gordorayado){
					me_sigue = false;
					estado = Estados.quieto;
					posicion = lerpinicial;
					//regresoPosicion();
					UnFantasmaMenos ();
					Invoke ("regresoPosicion", 2);
				}
					
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
	}

	void QuietoAgain(){
		if (!me_sigue) {
			estado = Estados.quieto;
			me_sigue = false;
		}
	}
	
	
	public void SetDentro(bool seg){
		dentro = seg;
	}
	
	public void regando(){
		if (!me_sigue) {
			
			estado = Estados.huyendo_boton;
		}
	}
	
	public void transcendiendo(){
		estado = Estados.transcendiendo;
		animgordo.SetBool("transcendiendo",true);
	}

	public void gordoLlorando(){
		estado = Estados.llorando;
	}
	
	public void destroy(){
		Destroy (gameObject);
	}

	public void regresoPosicion(){
		if (!me_sigue) {
			estado = Estados.huyendo_boton;
		}
	}
}
