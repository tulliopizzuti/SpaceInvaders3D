using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject m_shotPrefab;
    private Transform drone;
    public float speed = 0.05F;
    public float maxBound = 4.5F, minBound = -4.5F;
    private GameObject lastShot;
    void Start()
    {
        drone = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if (drone.position.x < minBound && h < 0)
            h = 0;
        else if (drone.position.x > maxBound && h > 0)
            h = 0;
        drone.position += Vector3.right * h * speed;
        if (Input.GetKeyDown(KeyCode.Space) && lastShot == null)
        {
            lastShot = GameObject.Instantiate(m_shotPrefab, drone.position, drone.rotation) as GameObject;
            GameObject.Destroy(lastShot, 3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("shotEnemy_prefab"))
        {

        }
    }
}
