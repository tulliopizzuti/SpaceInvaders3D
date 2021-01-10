using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("shot_prefab") || collision.gameObject.name.StartsWith("shotEnemy_prefab"))
        {
            Destroy(collision.gameObject);
            Destroy(GetComponent<Transform>().gameObject);
        }
    }
}
