using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VALORESINICIALES : MonoBehaviour {

	public float F; //  Fuerza de empuje [N] del campo sobre el microrobot
	public float Hh; //  Intensidad de campo magnético [A/m] generado por las bobinas Helmontz
	public float BHX_n, BHX_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en x
	public float BHY_n, BHY_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en y
	public float BHZ_n, BHZ_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en z
	public float BM_n, BM_r; // Numero de vueltas [] y radio [m] de la bobina maxwell
	public float MR_M,MR_r; // Intensidad de magnetización [A/m] y radio [m] del microrobot
	public float dens; // Densidad [kg/m^3] del microrobot
	public float ur; // Permeabilidad magnética relativa del medio []
	public float FD; // Fuerza de empuje [N] del medio al microrobot
	public float TD; // Torque generado por el medio al microrobot [Nm]

	public BobinasHelmontz BH;
	public BobinasMaxwell BM;
	public ParBobinasHelmontz BHX,BHY,BHZ;
	public ParBobinasMaxwell BM_;
	public Microrobot MR;
	public ConstantesMagneticas CM;
	public Rigidbody RB;

	void Update () {
		if (!Application.isPlaying) {

	
			BM.F = F;
			BH.Hh = Hh;
			BHX.n = BHX_n;
			BHY.n = BHY_n;
			BHZ.n = BHZ_n;

			BHX.r = BHX_r;
			BHY.r = BHY_r;
			BHZ.r = BHZ_r;

			BM_.n = BM_n;
			BM_.r = BM_r;

			MR.M = MR_M;
			MR.r = MR_r;
			MR.d = dens;
			MR.actualizarValores ();

			CM.ur = ur;
			CM.u = ur * CM.u0;
			RB.drag = FD;
			RB.angularDrag = TD;
		}
	}
}
