using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinasHelmontz : MonoBehaviour {

	ParBobinasHelmontz HelmontzX,HelmontzY,HelmontzZ;

	public float Hh;                                      //  [A/m]
	public float theta;                                   //  [deg]
	public float phi;                                     //  [deg]
	public Vector3 HhV;                                   //  [A/m]

	float K = Mathf.Pow (4f / 5f, 3f / 2f);               //  []
	public float torque; // 						      //  [N m]

	public double Ix,Iy,Iz;

	GeneradorDeTorqueMagnetico GTM;

	CampoHelmontz CH;

	void Awake () {
		HelmontzX = transform.Find ("HelmontzX").gameObject.GetComponent<ParBobinasHelmontz> ();
		HelmontzY = transform.Find ("HelmontzY").gameObject.GetComponent<ParBobinasHelmontz> ();
		HelmontzZ = transform.Find ("HelmontzZ").gameObject.GetComponent<ParBobinasHelmontz> ();
		CH = transform.Find ("LineasDeCampo").gameObject.GetComponent<CampoHelmontz> ();
		GTM = transform.Find ("GeneradorTorqueMagnetico").gameObject.GetComponent<GeneradorDeTorqueMagnetico> ();
	}

    public void calcularTodo() {
        calcularCorrientes();
        calcularVectorH();
        CH.actualizarVector();
        GTM.ActualizarVectorDirector(theta, phi);
    }

	public void calcularCorrientes () {
		
		Ix = ((Hh * HelmontzX.r) / (HelmontzX.n * K)) * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Cos (phi * Mathf.Deg2Rad);
		Iy = ((Hh * HelmontzY.r) / (HelmontzY.n * K)) * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Sin (phi * Mathf.Deg2Rad);
		Iz = ((Hh * HelmontzZ.r) / (HelmontzZ.n * K)) * Mathf.Cos (theta * Mathf.Deg2Rad);

		HelmontzX.I = Ix;
		HelmontzY.I = Iy;
		HelmontzZ.I = Iz;

		//Debug.Log ("Corrientes:    IX = " + HelmontzX.I + "A    IY = " + HelmontzY.I + "A    IZ = " + HelmontzZ.I + "A");
	}

	public void calcularVectorH(){
		float x =  Hh * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Cos (phi * Mathf.Deg2Rad);
		float y =  Hh * Mathf.Sin (theta * Mathf.Deg2Rad) * Mathf.Sin (phi * Mathf.Deg2Rad);
		float z =  Hh * Mathf.Cos (theta * Mathf.Deg2Rad);
		HhV = new Vector3 (x, y, z);
		CH.Hh = HhV;
	}
}
