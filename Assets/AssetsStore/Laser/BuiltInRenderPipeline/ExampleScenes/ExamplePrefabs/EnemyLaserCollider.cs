using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("shot_prefab"))
        {
            Destroy(collision.gameObject);
            Destroy(GetComponent<Transform>().gameObject);
        }
    }
}
