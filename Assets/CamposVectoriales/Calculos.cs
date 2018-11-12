using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Calculos  {
	public static Vector3 RotacionX(Vector3 V, float theta){
		return new Vector3 (
			V.x,
			V.y * Mathf.Cos (theta) - V.z * Mathf.Sin (theta),
			V.y * Mathf.Sin (theta) + V.z * Mathf.Cos (theta)
		);
	}

	public static Vector3 RotacionY(Vector3 V, float theta){
		return new Vector3 (
			V.x * Mathf.Cos (theta)   + V.z * Mathf.Sin (theta),
			V.y,
			V.z * Mathf.Cos (theta)   - V.x * Mathf.Sin (theta)
		);
	}

	public static Vector3 RotacionZ(Vector3 V, float theta){
		return new Vector3 (
			V.x * Mathf.Cos (theta) + V.y * Mathf.Sin (theta),
			V.x * Mathf.Sin (theta) - V.y * Mathf.Cos (theta) ,
			V.z
		);
	}

	public static float calcularRo(Vector3 Q){
		float ro = Mathf.Sqrt (Mathf.Pow (Q.x, 2) + Mathf.Pow (Q.y, 2) + Mathf.Pow (Q.z, 2));
		return ro;
	}

	public static float calcularTheta(Vector3 Q){
		float theta = Mathf.Atan2 (Mathf.Sqrt (Mathf.Pow (Q.y, 2) + Mathf.Pow (Q.x, 2)), Q.z);
		return theta;
	}

	public static float calcularPhi(Vector3 Q){
		float phi = Mathf.Atan2 (Q.y, Q.x);
		return phi;
	}

	public static Vector3 Rotacion(Vector3 V, float theta, float phi){
		Vector3 VY = Calculos.RotacionY (V, theta);
		Vector3 VZY= Calculos.RotacionZ(VY,phi);
		return VZY;
	}

	public static Vector3 trans(Vector3 u){
		return new Vector3 (u.x, u.z, u.y);
	}

	public static float map(float x, float in_min, float in_max, float out_min, float out_max)	{
		float F = (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
		if (float.IsNaN (F)) {
			F = 0f;
		}
		return F;
	}

	public static List<float> eliminarRepetidos(float [] v){
		List<float> vl = new List<float> (v);
		int nan = -1;

		vl = vl.Distinct ().ToList();

		for (int i = 0; i < vl.Count; i++) {
			if (float.IsNaN (vl.ElementAt (i))) {
				nan = i;

			}
		}

		if (nan != -1) {
			//Debug.Log ("Borrado el nan: " + nan);
			vl.RemoveAt (nan);
		}
		vl.Sort ();
		return vl;
	}

	public static float curvo(float n,float b){
		float r = Mathf.Pow (n, b);
		return r;
	}

}
