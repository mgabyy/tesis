using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeFuerzaMagnetico : MonoBehaviour {

	public GameObject MRGO;
	Rigidbody rb;

	public BobinasMaxwell BM;

	void Awake(){
		rb = MRGO.GetComponent<Rigidbody> ();
	}


	public void Desplazar (float Dir_X_F) {
		rb.AddForce (MRGO.transform.up * Dir_X_F,ForceMode.Acceleration);
	}
}
