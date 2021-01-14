using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("shot_prefab"))
        {

            Destroy(collision.gameObject);
            GameObject enemy = GetComponent<Transform>().gameObject;
            string tag = enemy.tag;
            Destroy(enemy);
            PlayerScore.GetInstancePlayerScore().ScoreCounter(tag);
        }
    }
}
