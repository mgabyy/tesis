using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

	public float vr;
	public BobinasHelmontz BH;


	void Start () {
		BH.calcularTodo ();
	}

	void FixedUpdate (){
		capturarTeclado ();
	}

	private void capturarTeclado(){
	
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) { 

			BH.theta -= Input.GetAxis ("Vertical") * vr;

			BH.theta = Mathf.Max (BH.theta, 0f);
			BH.theta = Mathf.Min (BH.theta, 180f);

			BH.phi += Input.GetAxis ("Horizontal") * vr;

			if (BH.phi > 360f) {
				BH.phi = BH.phi - 360f;
			}

			if (BH.phi < 0f) {
				BH.phi = BH.phi + 360f;
			}
			BH.calcularTodo ();
		}
	}

}
