using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinasMaxwell : MonoBehaviour {

	ParBobinasMaxwell Maxwell;
	public Microrobot MR;
	GeneradorDeFuerzaMagnetico GFM;
	public ConstantesMagneticas CM;

	public double I;

	public float F; // 						      //  [N]

	public float K = (16f/3f) *Mathf.Pow (3f / 7f, 5f / 2f)*Mathf.Pow (3f / 2f, 1f / 2f);   

	void Awake () {
		Maxwell = gameObject.GetComponent<ParBobinasMaxwell> ();
		GFM = transform.Find ("../GeneradorFuerzaMagnetica").gameObject.GetComponent<GeneradorDeFuerzaMagnetico> ();
	}

	public void calcularTodo(){
		calcularCorrientes ();
	}

	public void calcularCorrientes () {
		I = (F * Mathf.Pow (Maxwell.r, 2)) / (K * Maxwell.n * MR.V * MR.M * CM.u);
		//Debug.Log(((K * Maxwell.n * MR.V * MR.M * CM.u))+"  " + K +"  " + Maxwell.n +"  " + MR.V +"  " + MR.M +"  " + CM.u0);
		Maxwell.I = I;
	}

	public void Desplazar(float Dir){
		GFM.Desplazar (Dir*F);
	}	

}
