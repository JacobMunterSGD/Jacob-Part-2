using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaonSpawner : MonoBehaviour
{

    public GameObject axe;

    public void spawnAxe()
    
    {
        Instantiate(axe);
    }
}
