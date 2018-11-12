using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Microrobot : MonoBehaviour {

	public float r;     // [m]
	public float V;     // [m ^ 3]
	public float m;     // []
	public Vector3 M;
	void Update(){
		if (!Application.isPlaying) {
			actualizarValores();
		}
	}

	public void actualizarValores(){
		gameObject.transform.localScale = new Vector3 (r, r, r);
		V = (4f / 3f) * Mathf.PI * Mathf.Pow (r, 3);
	}

	public void actualizarVectorM(){
		float theta = -gameObject.transform.localEulerAngles.z;
		float phi = -gameObject.transform.localEulerAngles.y;
		float x = Mathf.Sin (theta * Mathf.Deg2Rad)*Mathf.Cos (phi * Mathf.Deg2Rad);
		float y = Mathf.Sin (theta * Mathf.Deg2Rad)*Mathf.Sin (phi * Mathf.Deg2Rad);
		float z = Mathf.Cos (theta * Mathf.Deg2Rad);
		M = new Vector3 (x, y, z);
	}

}
