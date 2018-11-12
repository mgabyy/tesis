using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinasHelmontz : MonoBehaviour {

	BobinaHelmontz HelmontzX,HelmontzY,HelmontzZ;

	public float Hh;                                      //  [T] o [G]
	public string Unidades;                               //  "T" o "G"
	public float theta;                                   //  [deg]
	public float phi;                                     //  [deg]
	public Vector3 HhV;                                   //  [T] o [G]

	float K = Mathf.Pow (4f / 5f, 3f / 2f);               //  []
	double Am2T = 0.0000012566370614f;                    //  [ (T * m) / A]
	double Am2G = 0.012566370614;                         //  [ (G * m) / A]
	public float torque; // 									  //  [Nm]

	GeneradorDeTorqueMagnetico GTM;

	CampoHelmontz CH;

	void Awake () {
		HelmontzX = transform.Find ("HelmontzX").gameObject.GetComponent<BobinaHelmontz> ();
		HelmontzY = transform.Find ("HelmontzY").gameObject.GetComponent<BobinaHelmontz> ();
		HelmontzZ = transform.Find ("HelmontzZ").gameObject.GetComponent<BobinaHelmontz> ();
		CH = transform.Find ("LineasDeCampo").gameObject.GetComponent<CampoHelmontz> ();
		GTM = transform.Find ("GeneradorTorqueMagnetico").gameObject.GetComponent<GeneradorDeTorqueMagnetico> ();
	}

	public void calcularTodo(){
		calcularCorrientes ();
		calcularVectorH ();
		CH.actualizarVector ();
		GTM.ActualizarVectorDirector (theta, phi);
	}

	public void calcularCorrientes () {
		
		double F = 0;
		switch (Unidades) {
		case "G":
			F = Am2G;
			break;
		case "T":
			F = Am2T;
			break;

		}

		HelmontzX.I = (Hh * HelmontzX.r) / (HelmontzX.n * K * F) * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Cos (phi * Mathf.Deg2Rad);
		HelmontzY.I = (Hh * HelmontzY.r) / (HelmontzY.n * K * F) * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Sin (phi * Mathf.Deg2Rad);
		HelmontzZ.I = (Hh * HelmontzZ.r) / (HelmontzZ.n * K * F) * Mathf.Cos (theta * Mathf.Deg2Rad);

		Debug.Log ("Corrientes:    IX = " + HelmontzX.I + "A    IY = " + HelmontzY.I + "A    IZ = " + HelmontzZ.I + "A");
	}

	public void calcularVectorH(){
		float x =  Hh * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Cos (phi * Mathf.Deg2Rad);
		float y =  Hh * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Sin (phi * Mathf.Deg2Rad);
		float z =  Hh * Mathf.Cos (theta * Mathf.Deg2Rad);
		HhV = new Vector3 (x, y, z);
		CH.Hh = HhV;
	}
}
