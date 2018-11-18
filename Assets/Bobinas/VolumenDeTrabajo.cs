using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class VolumenDeTrabajo : MonoBehaviour {

	public ParBobinasHelmontz HelmontzX,HelmontzY,HelmontzZ;

	void Awake () {
		HelmontzX = transform.Find ("../HelmontzX").gameObject.GetComponent<ParBobinasHelmontz> ();
		HelmontzY = transform.Find ("../HelmontzY").gameObject.GetComponent<ParBobinasHelmontz> ();
		HelmontzZ = transform.Find ("../HelmontzZ").gameObject.GetComponent<ParBobinasHelmontz> ();
	}


	void Update () {
		if (!Application.isPlaying) {
			actualizarVolumen ();
		}
	}

	void actualizarVolumen(){
		float x = Mathf.Min (HelmontzX.D, 2*(HelmontzY.r + HelmontzY.th));
		float y = Mathf.Min (HelmontzY.D, 2*(HelmontzX.r + HelmontzX.th));
		float z = Mathf.Min (HelmontzZ.D, 2*(HelmontzY.r + HelmontzY.th));
		z = Mathf.Min (z, 2 * (HelmontzX.r + HelmontzX.th));
		gameObject.transform.localScale = new Vector3 (x, z, y);
	}
}
