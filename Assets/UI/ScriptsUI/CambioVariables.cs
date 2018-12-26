using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioVariables : MonoBehaviour {

    public InputField T_Theta;
    public InputField T_Phi;
    public InputField T_F;
    public InputField T_Hh;
    public InputField T_NBHX;
    public InputField T_RBHX;
    public InputField T_NBHY;
    public InputField T_RBHY;
    public InputField T_NBHZ;
    public InputField T_RBHZ;
    public InputField T_NBM;
    public InputField T_RBM;
    public InputField T_MR_M;
    public InputField T_MR_r;
    public InputField T_MR_dens;
    public InputField T_Ur;
    public InputField T_FD;
    public InputField T_TD;

    CambioEnInputs cambioEnInputs;

    void Awake() {
        cambioEnInputs = GetComponent<CambioEnInputs>();
    }


    //PanelDatos

    public void CambioTheta(string ns) {
        T_Theta.text = ns;
        cambioEnInputs.CambioTheta(ns);
    }

    public void CambioPhi(string ns) {
        T_Phi.text = ns;
        cambioEnInputs.CambioPhi(ns);
    }

    public void Desplazar(float v) {
        cambioEnInputs.Desplazar(v); 
    }

    //PanelConsig - Magnitudes

    public void CambioFuerza(string ns) {
        T_F.text = ns;
        cambioEnInputs.CambioFuerza(ns);
    }

    public void CambioIntensidadDeCampoMagnetico(string ns) {
        T_Hh.text = ns;
        cambioEnInputs.CambioIntensidadDeCampoMagnetico(ns);
    }

    //PanelConsig - Bobinas

    public void CambioNBHX(string ns) {
        T_NBHX.text = ns;
        cambioEnInputs.CambioNBHX(ns);
    }

    public void CambioRBHX(string ns) {
        T_RBHX.text = ns;
        cambioEnInputs.CambioRBHX(ns);
    }

    public void CambioNBHY(string ns) {
        T_NBHY.text = ns;
        cambioEnInputs.CambioNBHY(ns);
    }

    public void CambioRBHY(string ns) {
        T_RBHY.text = ns;
        cambioEnInputs.CambioRBHY(ns);
    }

    public void CambioNBHZ(string ns) {
        T_NBHZ.text = ns;
        cambioEnInputs.CambioNBHZ(ns);
    }

    public void CambioRBHZ(string ns) {
        T_RBHZ.text = ns;
        cambioEnInputs.CambioRBHZ(ns);
    }

    public void CambioNBM(string ns) {
        T_NBM.text = ns;
        cambioEnInputs.CambioNBM(ns);
    }

    public void CambioRBM(string ns) {
        T_RBM.text = ns;
        cambioEnInputs.CambioRBM(ns);
    }

    //PanelConsig - MicroRobot

    public void CambioM_MR(string ns) {

        T_MR_M.text = ns;
        cambioEnInputs.CambioM_MR(ns);
    }

    public void CambioR_MR(string ns) {

        T_MR_r.text = ns;
        cambioEnInputs.CambioR_MR(ns);
    }

    public void CambioD_MR(string ns) {

        T_MR_dens.text = ns;
        cambioEnInputs.CambioD_MR(ns);
    }

    //PanelConsig - Medio

    public void CambioUr(string ns) {
        T_Ur.text = ns;
        cambioEnInputs.CambioUr(ns);
    }

    public void CambioFD(string ns) {
        T_FD.text = ns;
        cambioEnInputs.CambioFD(ns);
    }

    public void CambioTD(string ns) {
        T_TD.text = ns;
        cambioEnInputs.CambioTD(ns);
    }
}
