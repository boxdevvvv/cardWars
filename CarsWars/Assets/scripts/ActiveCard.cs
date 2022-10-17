using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveCard : MonoBehaviour
{
    public Sprite[] cartas;
    public int numeroAtque;
    private void OnEnable()
    {
        numeroAtque = Random.Range(0, 4);
        GetComponent<Image>().sprite = cartas[numeroAtque];
    }


    public BattleManager _battle;

    public void SeleccionAtaque()
    {
        if(numeroAtque == 0)
        {
            _battle.Ataque();
        }
        if(numeroAtque == 1 )
        {
            _battle.seducir();
        }
        if(numeroAtque == 2)
        {
            _battle.Defensa();
        }
        if(numeroAtque == 3)
        {
            _battle.pocion();
        }
    }
}
