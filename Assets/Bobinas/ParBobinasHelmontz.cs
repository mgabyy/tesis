using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParBobinasHelmontz : MonoBehaviour {


	public double I; // [A] -- Corriente que pasa por la bobina
	public float n;  // [ ] -- Numero de espiras de corriente
	public float D;  // [m] -- Distancia entre las bobinas
	public float r;  // [m] -- Radio interno de las bobinas
	public float h;  // [m] -- Altura de las bobinas
	public float th; // [m] -- Grosor de las bobinas

	GameObject bobinaA,bobinaB;

	void Awake () {

		bobinaA = transform.Find ("bobinaA").gameObject;
		bobinaB = transform.Find ("bobinaB").gameObject;

	}


	void Update(){
		if (!Application.isPlaying) {
			posicionar ();
			dimensionar ();
		}

	}

	void posicionar(){
		Vector3 posicionA = bobinaA.transform.localPosition;
		Vector3 posicionB = bobinaB.transform.localPosition;

		posicionA.y = D/2;
		posicionB.y = -D/2;

		bobinaA.transform.localPosition = posicionA;
		bobinaB.transform.localPosition = posicionB;

	}

	public void dimensionar(){
		bobinaA.GetComponent<Tube> ().h = h;
		bobinaA.GetComponent<Tube> ().r = r;
		bobinaA.GetComponent<Tube> ().th = th;
		bobinaA.GetComponent<Tube> ().draw ();

		bobinaB.GetComponent<Tube> ().h = h;
		bobinaB.GetComponent<Tube> ().r = r;
		bobinaB.GetComponent<Tube> ().th = th;
		bobinaB.GetComponent<Tube> ().draw ();

	}
		

}
