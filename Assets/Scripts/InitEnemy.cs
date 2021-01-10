using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemy : MonoBehaviour
{
    private Transform enemyHolder;
    private List<Transform> initialEnemies;
    public int[] xPosition = { -4, -3, -2, -1, 1, 2, 3, 4 };
    // Start is called before the first frame update
    void Awake()
    {
        initialEnemies = new List<Transform>();
        enemyHolder = GetComponent<Transform>();
        foreach (Transform enemy in enemyHolder)
        {
            initialEnemies.Add(enemy);
        }
        foreach (Transform enemy in initialEnemies)
        {
            foreach (int x in xPosition)
            {
                Transform clone = Instantiate(enemy,
                    new Vector3(x, enemy.position.y, enemy.position.z),
                    enemy.rotation,
                    enemyHolder
                    );
                clone.transform.parent = enemyHolder;
            }

        }
    }


}
