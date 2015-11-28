using UnityEngine;
using System.Collections;

public class arbol_jardinero : MonoBehaviour {
	scriptJardinero jardinero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D objeto){

		if (objeto.transform.tag == "Jardinero") {
			jardinero = objeto.GetComponent<scriptJardinero>();
			jardinero.regando();

		}
	}
}
