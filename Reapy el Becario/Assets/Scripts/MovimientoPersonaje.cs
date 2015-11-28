using UnityEngine;
using System.Collections;

public class MovimientoPersonaje : MonoBehaviour 
{
	public float fuerzaSalto;
	public float velocidad = 10f;
	private int numsaltos=0;

	Rigidbody2D rg;

	//Para luego meterle la animacion
	//private Animator anim;

	//creamos dos vectores, uno para la mira derecha y otro para la izq
	private Vector3 miraDerecha= new Vector3(1f,1f); 
	private Vector3 miraIzquierda= new Vector3(-1f,1f); 


	void Start () 
	{
		rg= GetComponent<Rigidbody2D>();
		/*
		anim = GetComponent<Animator>();
		//invertimos una de las escalas
		miraIzquierda = new Vector3(-transform.localScale.x,transform.localScale.y,transform.localScale.z); 
		//escala por defecto
		miraDerecha = transform.localScale; 
		 */
	}
	
	void Update () 
	{
		//Controles Salto
		//Para que salte nuestro personaje tenemos que pulsar Espacio
		/*
		if(Input.GetKeyUp(KeyCode.UpArrow))
		{
			//Tenemos un contador numsaltos que es 1, porque se ejecuta
			 //* una vez hemos pulsado espacio, por lo tanto siempre tendremos el contador en 1
			 //* *
			numsaltos=1;
			if(numsaltos==1)
			{
				salto();
				GetComponent<Rigidbody2D>().AddForce (new Vector2(fuerzaSalto,fuerzaSalto));
				//Personaje.rg.AddForce(new Vector3 (0,10,0)), ForceMode.VelocityChange);
			}
		}
		*/

		//Controles Izquierda Derecha
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			MovimientoIzq();
		}
		
		if(Input.GetKey(KeyCode.RightArrow)){
			MovimientoDrch();
		}
		//Para insertar la animacion de caminar
		//anim.SetFloat("caminando", Mathf.Abs(velocidad.x));
		Vector2 velocidad = GetComponent<Rigidbody2D>().velocity;
		Debug.DrawLine(transform.position, new Vector3(transform.position.x+ velocidad.x,
		                                               transform.position.y + velocidad.y, transform.position.z));
	}


	void salto()
	{
		//Aplicamos una fuerza en el salto en el eje Y
		rg.AddForce(new Vector2 (0, fuerzaSalto));
	}

	void MovimientoIzq()
	{
		transform.localScale=miraIzquierda;	
		/*De esta forma la velocidad siempre sera constante, el rg.velocity.y es 
		 * para q caiga a la vez que salta
		*/
		rg.velocity  = new Vector2 (-velocidad, 0);
	
	}
	void MovimientoDrch()
	{
		transform.localScale=miraDerecha;	
		/*De esta forma la velocidad siempre sera constante, el rg.velocity.y es 
		 * para q caiga a la vez que salta
		*/
		rg.velocity  = new Vector2(velocidad,0);
		
	}
}
