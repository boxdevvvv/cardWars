using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BattleManager : MonoBehaviour
{
   
    public GameObject canvas;
    public GameObject desactivadorCanvas;
    public Animator battleAnims;
    public void AmorSelection()
    {
        battleAnims.SetTrigger("Seduccion");
        camaraSeduccion.SetActive(true);
        camaraAtaque.SetActive(false);
        principalCamera.SetActive(false);
        canvas.SetActive(false);
    }
    public GameObject camaraAtaque;
    public GameObject camaraSeduccion;
    public GameObject principalCamera;
    public void AtackSelection()
    {
        principalCamera.SetActive(false);
        camaraSeduccion.SetActive(false);
        camaraAtaque.SetActive(true);
        battleAnims.SetTrigger("Attack");
        canvas.SetActive(false);
    }

}
