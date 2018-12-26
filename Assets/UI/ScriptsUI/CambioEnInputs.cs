using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioEnInputs : MonoBehaviour {

    public Dropdown DDIntensidadDeCampoMagnetico;
    public Dropdown DDMagnitudMagnetizacionMR;

    ParametrosMR parametrosMR;
    CambioEnObjetos cambioEnObjetos;

    void Awake() {
        parametrosMR = GetComponent<ParametrosMR>();
        cambioEnObjetos = GetComponent<CambioEnObjetos>();
    }
    
    //PanelDatos

    public void CambioTheta(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioTheta(nf);
    }

    public void CambioPhi(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioPhi(nf);
    }

    //PanelConfig - Magnitudes

    public void CambioFuerza(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioFuerza(nf);
    }

    public void CambioIntensidadDeCampoMagnetico(string ns) {
        float nf = float.Parse(ns);
        int unidad = DDIntensidadDeCampoMagnetico.value;

        nf = nf * x2AM(unidad);
        
        cambioEnObjetos.CambioIntensidadDeCampoMagnetico(nf);
    }

    public void Desplazar(float v) {
        cambioEnObjetos.Desplazar(v);
    }

    //PanelConfig - Bobinas

    public void CambioNBHX(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioNBHX(nf);
    }

    public void CambioRBHX(string ns) {
        float nf = float.Parse(ns)/100f;
        cambioEnObjetos.CambioRBHX(nf);
    }
    
    public void CambioNBHY(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioNBHY(nf);
    }

    public void CambioRBHY(string ns) {
        float nf = float.Parse(ns) / 100f;
        cambioEnObjetos.CambioRBHY(nf);
    }

    public void CambioNBHZ(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioNBHZ(nf);
    }

    public void CambioRBHZ(string ns) {
        float nf = float.Parse(ns) / 100f;
        cambioEnObjetos.CambioRBHZ(nf);
    }

    public void CambioNBM(string ns) {
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioNBM(nf);
    }

    public void CambioRBM(string ns) {
        float nf = float.Parse(ns) / 100f;
        cambioEnObjetos.CambioRBM(nf);
    }

    //PanelConfig - MicroRobot

    public void CambioM_MR(string ns) {
        parametrosMR.ActualizarDatos();
        float nf = float.Parse(ns);
        int unidad = DDMagnitudMagnetizacionMR.value;
        nf = nf * x2AM(unidad);
        cambioEnObjetos.CambioM_MR(nf);
    }

    public void CambioR_MR(string ns) {
        parametrosMR.ActualizarDatos();
        float nf = float.Parse(ns);

        cambioEnObjetos.CambioR_MR(nf);
    }

    public void CambioD_MR(string ns) {
        parametrosMR.ActualizarDatos();
        float nf = float.Parse(ns);
        cambioEnObjetos.CambioD_MR(nf);
    }

    //PanelConfig - Medio

    public void CambioUr(string ns) {
        float nf = float.Parse(ns);

        cambioEnObjetos.CambioUr(nf);
    }

    public void CambioFD(string ns) {
        float nf = float.Parse(ns);

        cambioEnObjetos.CambioFD(nf);
    }

    public void CambioTD(string ns) {
        float nf = float.Parse(ns);

        cambioEnObjetos.CambioTD(nf);
    }

    float x2AM(int n) {

        float T2AM = 795774.7154822216f;
        float G2AM = 79.57747154822215f;

        float retorno = 0f;

        switch (n) {
            case 0:
                retorno = 1f;
                break;
            case 1:
                retorno = T2AM;
                break;

            case 2:
                retorno = G2AM;
                break;

        }

        return retorno;
    }

}
