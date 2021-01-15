using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUfoController : MonoBehaviour
{
    public Transform baseUfo;
    private Transform ufo;
    public float minBound = -7.7f, maxBound = 7.7f;
    public float speed = 0.01F;
    
    public float ufoAppear = 20F;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateUfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (ufo != null)
        {
            ufo.position += Vector3.left * speed;
            if (ufo.position.x < minBound || ufo.position.x > maxBound)
            {
                Destroy(ufo.gameObject);
                Invoke("InstantiateUfo",ufoAppear);
            }
        }
        
    }

    private void InstantiateUfo()
    {
        ufo = GameObject.Instantiate(baseUfo.gameObject, new Vector3(baseUfo.position.x, 0.3f, baseUfo.position.z), baseUfo.rotation).transform;

    }
}
