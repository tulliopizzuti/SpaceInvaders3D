using UnityEngine;
using System.Collections;

public class EnemyShotBehavior : MonoBehaviour
{
	public float shotSpeed = 10F;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.position += transform.forward * Time.deltaTime * shotSpeed;

	}
}
