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
    public Text winText;
    public float fireRate = 0.997F;
    public GameObject m_shotPrefab;

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
        if (enemyHolder.childCount == 1) {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f,0.1f);
        }
        if (enemyHolder.childCount ==  0){
            //winText.enabled = true;
        }
    }
}

