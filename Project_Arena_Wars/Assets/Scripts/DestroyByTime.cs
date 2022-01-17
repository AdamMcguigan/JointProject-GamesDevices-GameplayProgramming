using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
	public float lifetime;

	//destroys items from the hierarchy
	void Start()
	{
		Destroy(gameObject, lifetime);
	}
}
