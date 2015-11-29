using UnityEngine;
using System.Collections;

public class ActivadorBlabla : MonoBehaviour {

	public GameObject particulasblabla;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	void OnTriggerEnter2D(Collider2D objeto)
	{
		if (objeto.transform.tag == "GordoFisica")
		{

			Instantiate(particulasblabla, transform.position, transform.rotation);

		}
	}
	
	
	void OnTriggerExit2D(Collider2D objeto) 
	{
		if (objeto.transform.tag == "GordoFisica" )
		{
			
		}
	}
}
