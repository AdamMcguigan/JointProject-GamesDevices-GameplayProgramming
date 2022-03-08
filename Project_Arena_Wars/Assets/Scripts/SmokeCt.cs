using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeCt : MonoBehaviour
{
	public Transform[] target;
	public Transform EndGoal;
	public float speed;

	private int current;

	void Update()
	{
		if (transform.position != EndGoal.transform.position)
		{
			if (transform.position != target[current].position)
			{
				Vector4 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
				GetComponent<Rigidbody2D>().MovePosition(pos);
			}
			else current = (current + 1) % target.Length;
		}
	}
}
