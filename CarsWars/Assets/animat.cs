using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animat : MonoBehaviour
{
    public GameObject canvas;
    private void OnEnable()
    {
        canvas.SetActive(true);
    }

}
