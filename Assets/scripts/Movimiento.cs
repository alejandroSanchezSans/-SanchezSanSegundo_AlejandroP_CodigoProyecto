using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movimiento  : MonoBehaviour
{
    public GameObject disco;
    


    public void Update() { 
        disco.transform.GetComponent<RectTransform>().Rotate(new Vector3(0f, 0f, 2f));
        }

   
}


