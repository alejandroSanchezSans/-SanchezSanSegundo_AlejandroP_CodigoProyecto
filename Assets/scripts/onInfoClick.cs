using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class onInfoClick : MonoBehaviour
{
    
    public GameObject panelInfo;
    public GameObject panelGeneral;


    public void onClickAceptar() {
        panelInfo.SetActive(false);
        panelGeneral.SetActive(true); 
    
    
    }
    public void onClickInfo()
    {
        panelGeneral.SetActive(false);
        panelInfo.SetActive(true);


    }

}
