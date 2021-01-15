using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("shot_prefab"))
        {

            if (m_Animator != null)
            {
                m_Animator.SetTrigger("Hit");
            }
            Destroy(collision.gameObject);
            GameObject enemy = GetComponent<Transform>().gameObject;
            string tag = enemy.tag;

            Destroy(enemy,0.5f);
            PlayerScore.GetInstancePlayerScore().ScoreCounter(tag);
            if (tag.Equals("0"))
            {
                RandomUfoController.GetInstanceRandomUfoController().ReloadUfoAppear();
            }
        }
    }
}
