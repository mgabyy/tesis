using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Microrobot : MonoBehaviour {

	public float M;     // [A/m]
	public float r;     // [m]
	public float V;     // [m ^ 3]
	public float d;     // [kg / m ^ 3]
	public float m;     // [kg]

	public Vector3 MV;
	void Update(){
		if (!Application.isPlaying) {
			actualizarValores();
		}
	}

	public void actualizarValores(){
		gameObject.transform.localScale = new Vector3 (r, r, r);
		V = (4f / 3f) * Mathf.PI * Mathf.Pow (r, 3);
		m = d * V;
		gameObject.GetComponent<Rigidbody> ().mass = m;
	}

	public void actualizarVectorM(){
		float theta = -gameObject.transform.localEulerAngles.z;
		float phi = -gameObject.transform.localEulerAngles.y;
		float x = Mathf.Sin (theta * Mathf.Deg2Rad)*Mathf.Cos (phi * Mathf.Deg2Rad);
		float y = Mathf.Sin (theta * Mathf.Deg2Rad)*Mathf.Sin (phi * Mathf.Deg2Rad);
		float z = Mathf.Cos (theta * Mathf.Deg2Rad);
		MV = new Vector3 (x, y, z);
	}

}
