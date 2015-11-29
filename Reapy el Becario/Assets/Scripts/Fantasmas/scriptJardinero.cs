using UnityEngine;
using System.Collections;

public class scriptJardinero : MonoBehaviour {

	Animator animjardinero;
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
	public enum Estados {quieto, siguiendo, regando_arbol, transcendiendo};
	public Estados estado; 
	bool regandofinal = false;
	public Transform punto_arbol;
	
	// Update is called once per frame
	void Start(){
		//		Bocadillo.SetActive(false);
		posicion = lerpinicial;
		animjardinero = GetComponent<Animator> ();
	}
	void Update () 
	{
		//Debug.Log (GameControl.fantasmaTeSigue);
		switch (estado){
			
		case Estados.quieto:
			animjardinero.SetBool("siguiendo",false);
			break;

		case Estados.siguiendo:
			animjardinero.SetBool("siguiendo",true);
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
			break;

		case Estados.regando_arbol:
			animjardinero.SetBool("regando", true);
			transform.position = Vector3.Lerp (transform.position, punto_arbol.position, posicion);
			regandofinal = true;
			break;

		case Estados.transcendiendo:


			break;
			
		default :
			//Debug.Log ("...");
			break;
		}

		if (dentro) {
			
			if (Input.GetKey (KeyCode.S) && !GameControl.fantasmaTeSigue && !regandofinal) {
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
	
	
	public void SetDentro(bool seg){
		dentro = seg;
	}

	public void regando(){
		if (!me_sigue) {

			estado = Estados.regando_arbol;
		}
	}

	public void transcendiendo(){
		estado = Estados.transcendiendo;
		animjardinero.SetBool("transcendiendo",true);
	}

	public void destroy(){
		Destroy (gameObject);
	}
}