using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class cameraFollow : MonoBehaviour
{
	public float speed = 15f;
	public float minDistance;
	public GameObject target;
	public Vector3 offset;
	//BTW i set the offset to -5 in the inspector, i thought that looked ok for the top down view, positive numbers is below the map

	private Vector3 targetPos;

	// Use this for initialization
	void Start()
	{
		targetPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		//lerping to the position of player 
		if (target)
		{
			//offsetting the position the the cam
			Vector3 posNoZ = transform.position + offset;
			//grabbing the direction the target is going 
			Vector3 targetDirection = (target.transform.position - posNoZ);
			//setting velocity
			float interpVelocity = targetDirection.magnitude * speed;
			//setting the target position aka players pos, this will track player pos 
			targetPos = (transform.position) + (targetDirection.normalized * interpVelocity * Time.deltaTime);
			//using the lerp method to make it move towards the players pos 
			transform.position = Vector3.Lerp(transform.position, targetPos, 0.25f);

		}
	}
}