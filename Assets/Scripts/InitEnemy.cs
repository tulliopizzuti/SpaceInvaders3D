using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEnemy : MonoBehaviour
{
    private Transform enemyHolder;
    private List<Transform> initialEnemies;
    public float[] xPosition = { -6f, -4.5f, -3f, -1.5F, 1.5f, 3f, 4.5f, 6f };
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
            foreach (float x in xPosition)
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
