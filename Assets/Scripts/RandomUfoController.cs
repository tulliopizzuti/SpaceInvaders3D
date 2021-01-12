using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUfoController : MonoBehaviour
{
    public Transform baseUfo;
    private Transform ufo;
    public float minBound = -5f, maxBound = 5f;
    public float speed = 0.01F;
    public float ufoAppear = 0.9F;
    // Start is called before the first frame update
    void Start()
    {
        ufo = GameObject.Instantiate(baseUfo.gameObject, new Vector3(baseUfo.position.x, 0.3f, baseUfo.position.z), baseUfo.rotation).transform;
    }

    // Update is called once per frame
    void Update()
    {
        ufo.position += Vector3.left * speed;
        if (ufo.position.x < minBound || ufo.position.x > maxBound)
        {
            Destroy(ufo.gameObject);
        }

        if (ufo == null)
        {
            if (Random.value > ufoAppear)
            {
                ufo = GameObject.Instantiate(baseUfo.gameObject, new Vector3(baseUfo.position.x, 0.3f, baseUfo.position.z), baseUfo.rotation).transform;
            }
        }
    }
}
