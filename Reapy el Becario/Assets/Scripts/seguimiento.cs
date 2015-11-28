using UnityEngine;
using System.Collections;

public class seguimiento : MonoBehaviour {
	public Transform player;
	public float speed = 1;
	private float posicion;
	private float distancia;
	private bool me_sigue = false;

	private bool dentro = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (GameControl.fantasmaTeSigue);

		if (dentro) {

			if (Input.GetKey (KeyCode.S)) {
				me_sigue = true;
			//	UnFantasmaMas ();
				//	Debug.Log ("Funciona");
			} else if (Input.GetKey (KeyCode.A)) {
				me_sigue = false;
			//	UnFantasmaMenos ();
			}
		}

		if (me_sigue) {
			//GameControl.fantasmaTeSigue = true;
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
		} else if (!me_sigue) {
			//GameControl.fantasmaTeSigue = false;
		}
		
		/*
			if(Input.GetKey(KeyCode.A))
			{
				me_sigue = !me_sigue;
			}
			*/
	}



	public void SetDentro(bool seg){
		dentro = seg;
	}


}
