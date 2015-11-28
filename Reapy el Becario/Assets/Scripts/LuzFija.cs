using UnityEngine;
using System.Collections;

public class LuzFija : MonoBehaviour {

	public float positionZ = -1;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, positionZ);
	}
}
