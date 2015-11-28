using UnityEngine;
using System.Collections;

public class ActivadorPolea: MonoBehaviour 
	
{
	ActivadorBoton botonscript;
	public string nombre_boton = "Boton";
	Animator polea;
	// Use this for initialization
	void Start () 
	{
		GameObject boton = GameObject.Find (nombre_boton);
		botonscript = boton.GetComponent<ActivadorBoton> ();
		polea = GetComponent<Animator>(); //animacion boton
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (botonscript.botonpulsado) {
			polea.SetBool ("boton", true);
		
		} else if (!botonscript.botonpulsado) {
			polea.SetBool ("boton", false);
		}
	}
}
