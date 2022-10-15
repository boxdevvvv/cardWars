using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
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
    }
    #region seleccion  de combate
    private void Update()
    {
        vidaPlayer.text = "Vida " + Playervida + "/3";
        vidaEnemy.text = "Vida " + EnemyVida + "/3";
        rondasTXT.text = "Rondas " + rondas;
        turnosTXT.text = "Turnos " + turnos;
        if(EnemyVida <= 0)
        {
            if(!activadoRestart)
            {
            activadoRestart = true;
            battleAnims.SetTrigger("OutEnemy");
            canvas.SetActive(false);
            Invoke("RestartEnemy", 5);
                rondas++;
            }
        }
    }
    public TextMeshProUGUI rondasTXT;
    public TextMeshProUGUI turnosTXT;

    private bool activadoRestart = false;
    public void RestartEnemy()
    {
        canvas.SetActive(true);
        EnemyVida = 3;
        activadoRestart = false;
    }


    public TextMeshProUGUI vidaPlayer;
    public TextMeshProUGUI vidaEnemy;
    public int cartaEnemigo;
    public int cartaPlayer;
    public int Playervida = 3;
    public int EnemyVida = 3;

    public int turnos=1;
    public int rondas=1;
    public void seleccionAtque(int _seleccionPlayer)
    {
        cartaEnemigo = Random.Range(0, 3);
        canvas.SetActive(false);
        Invoke("EnableCanvas", 3);

        if (_seleccionPlayer == 0 && cartaEnemigo == 0)
        {
            battleAnims.SetTrigger("AttackVsAttack");
            Playervida--;
            EnemyVida--;
        }
        if(_seleccionPlayer == 0 && cartaEnemigo == 2)
        {
            battleAnims.SetTrigger("Attack Vs Defense");
            Playervida--;
        } 
        if(_seleccionPlayer == 0 && cartaEnemigo == 1)
        {
            battleAnims.SetTrigger("Attack vs seduccion");
            EnemyVida--;
        }



        if (_seleccionPlayer == 2 && cartaEnemigo == 2)
        {
            battleAnims.SetTrigger("Defensa vs Defensa");
        }
        if (_seleccionPlayer == 2 && cartaEnemigo == 0)
        {
            battleAnims.SetTrigger("Defensa vs Ataque");
            EnemyVida--;
        }
        if (_seleccionPlayer == 2 && cartaEnemigo == 1)
        {
            battleAnims.SetTrigger("Defensa vs Seduccion");
            Playervida--;
        }

       

        if (_seleccionPlayer == 1 && cartaEnemigo == 0)
        {
            battleAnims.SetTrigger("Seduccion Vs Ataque");
            Playervida--;
        }
        if (_seleccionPlayer == 1 && cartaEnemigo == 1)
        {
            battleAnims.SetTrigger("Seduccion vs Seduccion");
            Playervida--;
            EnemyVida--;
        }
        if(_seleccionPlayer == 1 && cartaEnemigo == 2)
        {
            battleAnims.SetTrigger("Seduccion vs Defensa");
            EnemyVida--;
        }

        turnos++;
    }

    public void EnableCanvas()
    {
        if(!activadoRestart)
        {
        canvas.SetActive(true);

        }
    }
    #endregion

}
