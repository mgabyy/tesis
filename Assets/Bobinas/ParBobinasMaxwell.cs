using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParBobinasMaxwell : MonoBehaviour {


	public double I; // [A] -- Corriente que pasa por la bobina
	public float n;  // [ ] -- Numero de espiras de corriente
	public float r;  // [m] -- Radio interno de las bobinas

	public ParBobinasHelmontz BHZ;

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

		posicionA.y = BHZ.D/2+BHZ.h;
		posicionB.y = -BHZ.D/2-BHZ.h;

		bobinaA.transform.localPosition = posicionA;
		bobinaB.transform.localPosition = posicionB;

	}

	public void dimensionar(){
		//r = BHZ.r;
		bobinaA.GetComponent<Tube> ().h = BHZ.h;
		bobinaA.GetComponent<Tube> ().r = r;
		bobinaA.GetComponent<Tube> ().th = BHZ.th;
		bobinaA.GetComponent<Tube> ().draw ();

		bobinaB.GetComponent<Tube> ().h = BHZ.h;
		bobinaB.GetComponent<Tube> ().r = r;
		bobinaB.GetComponent<Tube> ().th = BHZ.th;
		bobinaB.GetComponent<Tube> ().draw ();

	}
		

}
