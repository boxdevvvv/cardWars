using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacks : MonoBehaviour
{
    void Update()
    {
        transform.forward = new Vector3(Camera.main.transform.forward.x, transform.forward.y, Camera.main.transform.forward.z);
    }
}
