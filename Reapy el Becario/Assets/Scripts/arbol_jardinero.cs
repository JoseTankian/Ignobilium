using UnityEngine;
using System.Collections;

public class arbol_jardinero : MonoBehaviour {

	scriptJardinero jardinero;
	scriptGimnasta gimnasta;
	Animator animArbol;

	public bool arbol_regado = false;
	public bool arbol_gimnasta = false;

	// Use this for initialization

	void Start () {
		animArbol = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (arbol_regado) {

		}

	}

	void OnTriggerStay2D(Collider2D objeto){

		if (objeto.transform.tag == "Jardinero") {
			jardinero = objeto.GetComponent<scriptJardinero>();
			jardinero.regando();
			animArbol.SetBool("creciendo", true);
		}

		if (objeto.transform.tag == "Gimnasta" && arbol_regado) {
			gimnasta = objeto.GetComponent<scriptGimnasta>();
			gimnasta.haciendoPirueta();
			animArbol.SetBool("moviendose", true);
		}

	}
	

	public void arbol_crecido(){
		arbol_regado = true;
	}

}
