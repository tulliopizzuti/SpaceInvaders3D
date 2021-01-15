using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public GameObject m_shotPrefab;
    private Transform drone;
    public float speed = 0.03F;
    public float maxBound = 7F, minBound = -7F;
    private GameObject lastShot;
    float delay = 0;
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
            GameObject.Destroy(lastShot, 2f);
        }
        if (delay > 0)
            delay -= Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (delay > 0)
            return;

        delay = 0.5f;
        if (collision.gameObject.name.StartsWith("shotEnemy_prefab"))
        {
            Destroy(collision.gameObject);
            PlayerScore.GetInstancePlayerScore().ReduceLives();
        }
    }
}
