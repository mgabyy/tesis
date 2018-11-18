using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour {

	public float vr;
	public float vt;
	public BobinasHelmontz BH;
	public BobinasMaxwell BM;

	public GameObject imOn,imOff,panelSAlir;
	bool cambio = false;

	void Start () {
		BH.calcularTodo ();
	}

	void FixedUpdate (){
	
		if (Input.GetKey("escape"))
		{
			panelSAlir.SetActive(true);
		}

		capturarTeclado ();
	}

	private void capturarTeclado(){

		float vertical = Input.GetAxis ("Vertical");
		float Horizontal = Input.GetAxis ("Horizontal");

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) { 

			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				BM.Desplazar (vertical * vt);
				imOn.SetActive (true);
				imOff.SetActive (false);
				cambio = true;
			} else {

				if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl)) {
					BH.theta -= vertical * vr;

					BH.theta = Mathf.Max (BH.theta, 0f);
					BH.theta = Mathf.Min (BH.theta, 180f);

					BH.phi += Horizontal * vr;

					if (BH.phi > 360f) {
						BH.phi = BH.phi - 360f;
					}

					if (BH.phi < 0f) {
						BH.phi = BH.phi + 360f;
					}
				}
			}
		} else {

			if (cambio) {
				imOn.SetActive (false);
				imOff.SetActive (true);
				cambio = false;
			}
		}
		BH.calcularTodo ();
		BM.calcularTodo ();
	}

	public void cerrarPrograma(){
		Application.Quit();
	
	}


	public void cancelarSalir(){
		panelSAlir.SetActive(false);
	}

}
