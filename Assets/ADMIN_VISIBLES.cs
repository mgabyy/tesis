using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ADMIN_VISIBLES : MonoBehaviour {
	
	public bool T_LDC, T_VM, T_BHX,T_BHY,T_BHZ,T_BM,T_MR,T_EDT;
	public GameObject LDC, VM, BHX,BHY,BHZ,BM,MR,EDT;

	void Start(){
		LDC.SetActive(true);
		VM.SetActive(true);
		BHX.SetActive(true);
		BHY.SetActive(true);
		BHZ.SetActive(true);
		BM.SetActive(true);
		MR.SetActive(true);
		EDT.SetActive(true);
		verONoVer ();
	}

	void Update () {
		if (!Application.isPlaying) {
			verONoVer ();
			}
		}

	void verONoVer(){
		LDC.SetActive(T_LDC);
		VM.SetActive(T_VM);
		BHX.SetActive(T_BHX);
		BHY.SetActive(T_BHY);
		BHZ.SetActive(T_BHZ);
		BM.SetActive(T_BM);
		MR.SetActive(T_MR);
		EDT.SetActive(T_EDT);
	}
}
