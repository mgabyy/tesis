using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParametrosIniciales : MonoBehaviour {
    public float theta; //  Fuerza de empuje [N] del campo sobre el microrobot
    public float phi; //  Fuerza de empuje [N] del campo sobre el microrobot
    public float F; //  Fuerza de empuje [N] del campo sobre el microrobot
    public float Hh; //  Intensidad de campo magnético [A/m] generado por las bobinas Helmontz
    public float BHX_n, BHX_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en x
    public float BHY_n, BHY_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en y
    public float BHZ_n, BHZ_r; // Numero de vueltas [] y radio [m] de la bobina helmotnz en z
    public float BM_n, BM_r; // Numero de vueltas [] y radio [m] de la bobina maxwell
    public float MR_M, MR_r, MR_dens; // Intensidad de magnetización [A/m] y radio [m] del microrobot y Densidad [kg/m^3] del microrobot
    public float ur; // Permeabilidad magnética relativa del medio []
    public float FD; // Fuerza de empuje [N] del medio al microrobot
    public float TD; // Torque generado por el medio al microrobot [Nm]

    public CambioVariables CV;


    private void Start() {
        CV.CambioTheta(theta + "");
        CV.CambioPhi(phi + "");
        CV.CambioFuerza(F + "");
        CV.CambioIntensidadDeCampoMagnetico(Hh + "");
        CV.CambioNBHX(BHX_n + "");
        CV.CambioRBHX(BHX_r * 100f + "");
        CV.CambioNBHY(BHY_n + "");
        CV.CambioRBHY(BHY_r * 100f + "");
        CV.CambioNBHZ(BHZ_n + "");
        CV.CambioRBHZ(BHZ_r * 100f + "");
        CV.CambioNBM(BM_n + "");
        CV.CambioRBM(BM_r * 100f + "");
        CV.CambioM_MR(MR_M + "");
        CV.CambioR_MR(MR_r * 100f + "");
        CV.CambioD_MR(MR_dens + "");
        CV.CambioUr(ur + "");
        CV.CambioFD(FD + "");
        CV.CambioTD(TD + "");
    }

   


}
