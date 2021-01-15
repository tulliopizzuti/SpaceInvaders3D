using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed=0.03F;
    public float minBound = -4.5F, maxBound=4.5F;
    public float maxHeight = -5F;
    public float fireRate = 0.997F;
    public GameObject m_shotPrefab;
    private bool last;
    // Start is called before the first frame update
    void Start()
    {
        //winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform> ();
        last = false;
    }

    // Update is called once per frame
    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;
        int i = 0;
        foreach (Transform enemy in enemyHolder){
            if (enemy.position.x < minBound || enemy.position.x> maxBound){
                speed = -speed;
                enemyHolder.position += Vector3.back * 0.5f;
                return;
            }
            i++;
            //Random.InitState(i);
            if (Random.value > fireRate)
            {
                GameObject go = GameObject.Instantiate(m_shotPrefab, enemy.position, enemy.rotation) as GameObject;           
                GameObject.Destroy(go, 3f);
            }
            if (enemy.position.z <= maxHeight)
            {
                Debug.Log("Perso");
                Time.timeScale = 0;
            }
        }
        if (enemyHolder.childCount == 1 && !last) {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f,0.1f);
            speed *= 10;
            last = true;
        }
        if (enemyHolder.childCount ==  0){
            Debug.Log("Vinto");
            Time.timeScale = 0;
        }
    }
}

