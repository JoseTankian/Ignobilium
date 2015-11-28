using UnityEngine;
using System.Collections;

public class ActivadorBoton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionStay2D(Collision2D objeto)
	{
		if (objeto.transform.tag == "Gordo")
		{
			Debug.Log ("El botonFunciona!!!!!");
		}
	}
}
