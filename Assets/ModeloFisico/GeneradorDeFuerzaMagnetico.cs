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
		rb.AddForce (MRGO.transform.up *0.1f*Mathf.Sign(Dir_X_F),ForceMode.Acceleration);
	}
}
