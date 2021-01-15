using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed=0.07f;
    public float minBound = -7F, maxBound=7F;
    public float maxHeight = -4F;
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
        foreach (Transform enemy in enemyHolder){
            if (enemy.position.x < minBound || enemy.position.x> maxBound){
                speed = -speed;
                enemyHolder.position += Vector3.back * 0.5f;
                return;
            }
            if (Random.value > fireRate)
            {
                Animator animator = enemy.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("Fire");
                }
                
                GameObject go = GameObject.Instantiate(m_shotPrefab, enemy.position, enemy.rotation) as GameObject;           
                GameObject.Destroy(go, 3f);
            }
            if (enemy.position.z <= maxHeight)
            {
                Debug.Log("Perso");
                Time.timeScale = 0;
                return;
            }
        }
        if (enemyHolder.childCount == 1 && !last) {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f,0.1f);
            speed *= 7;
            last = true;
        }
        if (enemyHolder.childCount ==  0){
            Debug.Log("Vinto");
            Time.timeScale = 0;
            return;
        }
    }
}

