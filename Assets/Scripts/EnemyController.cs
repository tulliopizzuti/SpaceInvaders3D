using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    public float minBound = -4.5F, maxBound=4.5F;

    public GameObject shot;
    public Text winText;
    public float fireRate = 0.997F;

    // Start is called before the first frame update
    void Start()
    {
        //winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        foreach (Transform enemy in enemyHolder){
            if (enemy.position.x < minBound || enemy.position.x> maxBound){
                speed = -speed;
                enemyHolder.position += Vector3.back * 0.5f;
                return;
            }

            if (enemy.position.y <= minBound){
                // GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }
        if (enemyHolder.childCount == 1) {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f,0.25f);
        }
        if (enemyHolder.childCount ==  0){
            //winText.enabled = true;
        }
    }
}

