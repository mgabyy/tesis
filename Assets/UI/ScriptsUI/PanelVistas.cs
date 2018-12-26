using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelVistas : MonoBehaviour {

	public GameObject LDC, VM, BHX,BHY,BHZ,BM,MR,EDT,CuerpoGO;
	public Toggle T_LDC, T_VM, T_BHX,T_BHY,T_BHZ,T_BM,T_MR,T_EDT,T_Cuerpo;

	void Start(){
        
		T_LDC.isOn = LDC.activeSelf;
		T_VM.isOn = VM.activeSelf;
		T_BHX.isOn = BHX.activeSelf;
		T_BHY.isOn = BHY.activeSelf;
		T_BHZ.isOn = BHZ.activeSelf;
		T_BM.isOn = BM.activeSelf;
		T_MR.isOn = MR.activeSelf;
		T_EDT.isOn = EDT.activeSelf;
        T_Cuerpo.isOn = CuerpoGO.activeSelf;
    }

	public void Toogle(int opcion){
        switch (opcion) {
            case 0:
                LDC.SetActive(T_LDC.isOn);
                break;
            case 1:
                VM.SetActive(T_VM.isOn);
                break;
            case 2:
                BHX.SetActive(T_BHX.isOn);
                break;
            case 3:
                BHY.SetActive(T_BHY.isOn);
                break;
            case 4:
                BHZ.SetActive(T_BHZ.isOn);
                break;
            case 5:
                BM.SetActive(T_BM.isOn);
                break;
            case 6:
                MR.SetActive(T_MR.isOn);
                break;
            case 7:
                EDT.SetActive(T_EDT.isOn);
                break;
            case 8:
                CuerpoGO.SetActive(T_Cuerpo.isOn);
                break;
        }

	}


}
