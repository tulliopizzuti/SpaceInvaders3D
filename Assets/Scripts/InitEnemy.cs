using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemy : MonoBehaviour
{
    private Transform enemyHolder;
    private Transform[] initialEnemies;
    // Start is called before the first frame update
    void Awake()
    {
       enemyHolder = GetComponent<Transform> ();
       initialEnemies = GetComponents<Transform> ();
    }

   
}
