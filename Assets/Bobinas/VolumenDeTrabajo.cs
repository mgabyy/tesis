using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class VolumenDeTrabajo : MonoBehaviour {

	public BobinaHelmontz HelmontzX,HelmontzY,HelmontzZ;

	void Awake () {
		HelmontzX = transform.Find ("../HelmontzX").gameObject.GetComponent<BobinaHelmontz> ();
		HelmontzY = transform.Find ("../HelmontzY").gameObject.GetComponent<BobinaHelmontz> ();
		HelmontzZ = transform.Find ("../HelmontzZ").gameObject.GetComponent<BobinaHelmontz> ();
	}


	void Update () {
		if (!Application.isPlaying) {
			actualizarVolumen ();
		}
	}

	void actualizarVolumen(){
		gameObject.transform.localScale = new Vector3 (HelmontzX.D, HelmontzZ.D, HelmontzY.D);
	}
}
