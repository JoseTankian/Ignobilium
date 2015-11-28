using UnityEngine;
using System.Collections;

public class ActivadorBoton : MonoBehaviour 
{
	
	public bool botonpulsado = false;
	Animator boton;
	// Use this for initialization
	void Start () 
	{
		boton = GetComponent<Animator>(); //animacion boton
	}
	
	// Update is called once per frame
	void Update () 
	{

		
	}
		
	
	void OnCollisionStay2D(Collision2D objeto)
	{
		if (objeto.transform.tag == "Gordo")
		{
			boton.SetBool("gordo",true);
			botonpulsado  = true;
			Debug.Log ("El botonFunciona!!!!!");
		}
	}


	void OnCollisionExit2D(Collision2D objeto) 
	{
		if (objeto.transform.tag == "Gordo")
		{
			boton.SetBool("gordo",false);
			botonpulsado  = false;
		}
	}
	
}
