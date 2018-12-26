using System;
using UnityEngine;
using UnityEngine.UI;

public class AdminDropdowns : MonoBehaviour {

    public InputField IF_HH;
    public InputField IF_MR;
    public BobinasHelmontz BH;
    public Microrobot MR;

    public void DD_IntensidadHH(Int32 sel) {
        float f = BH.Hh * AM2x(sel);
        IF_HH.text = f + "";
    }

    public void DD_MR_M(Int32 sel) {
        float f = MR.M * AM2x(sel);
        IF_MR.text = f + "";
    }

    float AM2x(int n) {

        float T2AM = 795774.7154822216f;
        float G2AM = 79.57747154822215f;

        float retorno = 0f;

        switch (n) {
            case 0:
                retorno = 1f;
                break;
            case 1:
                retorno = 1f/T2AM;
                break;

            case 2:
                retorno = 1f/G2AM;
                break;

        }

        return retorno;
    }

}
