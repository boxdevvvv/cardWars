using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;
public class BattleManager : MonoBehaviour
{
   
    public GameObject canvas;
    public GameObject desactivadorCanvas;
    public Animator battleAnims;


    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ReallyrESTASRT()
    {
        gameover.SetActive(true);
    }
    public void Ataque()
    {
        seleccionAtque(0);
    }
    public void Defensa()
    {
        seleccionAtque(2);
    }
    public void seducir()
    {
        seleccionAtque(1);
    }
    public void pocion()
    {
        seleccionAtque(3);
    }
    public GameObject gameover;
    private void Start()
    {
        enemigoSalido = Random.Range(0, 2);
        print(enemigoSalido);
        RestartEnemy();
    }
    public int enemigoSalido;
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


        if(Playervida >= 3)
        {
            Playervida = 3;
        }
        if(Playervida<= 0)
        {
            if(!died)
            {
                died = true;
            Invoke("ReallyrESTASRT", 3);
            }
        }
    }
    private bool died = false;
    public TextMeshProUGUI rondasTXT;
    public TextMeshProUGUI turnosTXT;
    private bool activadoRestart = false;
    public GameObject[] enemys;
    public RuntimeAnimatorController[] animaciones;
    
    public void RestartEnemy()
    {
        enemigoSalido = Random.Range(0, 2);
        enemys[0].SetActive(false);
        enemys[1].SetActive(false);

        if(enemigoSalido ==1)
        {
            battleAnims = enemys[enemigoSalido].GetComponent<Animator>();
            enemys[enemigoSalido].SetActive(true);
        }
        if
        (enemigoSalido == 0)
        {
            battleAnims = enemys[enemigoSalido].GetComponent<Animator>();

            enemys[enemigoSalido].SetActive(true);

        }
        canvas.SetActive(true);
        EnemyVida = 3;
        activadoRestart = false;


        print(enemigoSalido);
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
        Invoke("EnableCanvas", 5);

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
        if(_seleccionPlayer == 3)
        {
            Playervida++;
            canvas.SetActive(false);
            canvas.SetActive(true);
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
