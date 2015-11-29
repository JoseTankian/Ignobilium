using UnityEngine;
using System.Collections;

public class dentroPsicologo : MonoBehaviour {

	scriptPsicologo p;
	//scriptPsicologo p2;
	// Use this for initialization
	void Start () 
	{
		p=GetComponentInParent<scriptPsicologo>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			p.SetDentro(true);
			p.muerteSeAleja = false;
		}

		if (objeto.tag == "Gordo") {
			p.psicologoYGordoJuntos = true;
		}
		
	}
	
	void OnTriggerExit2D(Collider2D objeto)
	{
		if(objeto.tag== "Player")
		{
			p.SetDentro(false);
			p.muerteSeAleja = true;
		}

		if (objeto.tag == "Gordo") {
			p.psicologoYGordoJuntos = false;
		}
		
	}
}
