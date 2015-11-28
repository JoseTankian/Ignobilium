using UnityEngine;
using System.Collections;

public class seguimiento : MonoBehaviour {
	public Transform player;
	public float speed = 1;
	private float posicion;
	private float distancia;
	private bool me_sigue = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () 
	{
		if (me_sigue) 
		{
			posicion = (posicion + Time.deltaTime * speed / 100);
			transform.position = Vector3.Lerp (transform.position, player.transform.position, posicion);
		}
		/*
		if(Input.GetKey(KeyCode.A))
		{
			me_sigue = !me_sigue;
		}
		*/
	}

	void OnTriggerEnter2D(Collider2D objeto)
	{
		Debug.Log ("Contacto");

		if(objeto.transform.tag == "Player" && Input.GetKey(KeyCode.A)) // tambien se puede poner Debug.Log (objeto.name);
		{  
			me_sigue = !me_sigue;
			Debug.Log ("Funciona");
		}
	}


}
